
using DataTableCRUD.Helper;
using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    public class DeveloperController : BaseController
    {
        private readonly MyDatabaseEntities _context;
        //  public string DeveloperController { get; private set; }
        public DeveloperController()
        {
            _context = new MyDatabaseEntities();
        }
      
        // GET: Developer
        [Authorize (Roles ="Admin")]
       public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult getData()
        {
            var model = _context.Developers.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            return PartialView("_addData", new Developer());
        }
        [HttpPost]
        public ActionResult addData(Developer developer)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                developer.CreatedByUserId = 1;
                developer.CreatedByUserName = "Suraz";
                developer.CreatedByUSerDate = DateTime.Now;
                _context.Developers.Add(developer);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "";
            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();
                result.IsSuccess = false;
                result.Message = "Validation Failed";
            }
            return Json(result);
        }
        [HttpGet]
        public PartialViewResult editData(int id)
        {
            var model = _context.Developers.FirstOrDefault(x => x.DeveloperId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(Developer developer)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {


                _context.Entry(developer).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return Json(result);


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Developers.FirstOrDefault(x => x.DeveloperId == id);
            _context.Developers.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }

    }
}