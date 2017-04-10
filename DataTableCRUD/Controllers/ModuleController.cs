using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTableCRUD.Models;
using System.Data.Entity;
using DataTableCRUD.Helper;


namespace DataTableCRUD.Controllers
{
 
    
    public class JsonResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class ModuleController : BaseController
    {
        private readonly MyDatabaseEntities _context;
        public ModuleController()
        {
            _context = new MyDatabaseEntities();

        }
        // GET: Module
        
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult getData()
        {
            var model = _context.Modules.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            return PartialView("_addData", new Module());

        }
        [HttpPost]
        public ActionResult addData(Module module)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                module.CreatedByUserId = 1;
                module.CreatedByUserName = "Suraz";
                module.CreatedByUSerDate = DateTime.Now;
                _context.Modules.Add(module);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "SUCCESSFULLY ADDED";
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
            var model = _context.Modules.FirstOrDefault(x => x.ModuleId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(Module module)
        {


            if (ModelState.IsValid)
            {


                _context.Entry(module).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Modules.FirstOrDefault(x => x.ModuleId == id);
            _context.Modules.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }

}


