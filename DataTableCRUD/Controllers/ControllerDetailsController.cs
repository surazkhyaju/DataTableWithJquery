using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    public class ControllerDetailsController : Controller
    {
        private readonly MyDatabaseEntities _context;
        public ControllerDetailsController()
        {
            _context = new MyDatabaseEntities();
        }
        // GET: ControllerDetails
        public ActionResult Index()
        {
            return View();
        }
       
        public PartialViewResult getData()
        {
            var model = _context.ControllerDetails.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            ViewBag.Components = new SelectList(_context.Components.ToList(), "ComponentId", "ComponentName");
            return PartialView("_addData", new ControllerDetail());
        }
        [HttpPost]
        public ActionResult addData(ControllerDetail model)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                model.CreatedByUserId = 1;
                model.CreatedByUserName = "Suraz";
                model.CreatedByUSerDate = DateTime.Now;
                _context.ControllerDetails.Add(model);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Validation Failed";
            }
            return Json(result);
        }
        [HttpGet]
        public PartialViewResult editData(int id)
        {
            ViewBag.Components = new SelectList(_context.Components.ToList(), "ComponentId", "ComponentName");
            var model = _context.ControllerDetails.FirstOrDefault(x => x.ControllerId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(ControllerDetail postEdit)

        {
           
            if (ModelState.IsValid)
            {


                _context.Entry(postEdit).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.ControllerDetails.FirstOrDefault(x => x.ControllerId == id);
            _context.ControllerDetails.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }
}


    