using DataTableCRUD.Helper;
using DataTableCRUD.Models;
using DataTableCRUD.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
   
    public class DailyDeveloperTaskLogController : BaseController
    {
        private readonly MyDatabaseEntities _context;
        public DailyDeveloperTaskLogController()
        {
            _context = new MyDatabaseEntities();
        }
        public void PopulateDopDown()
        {
            ViewBag.Component = _context.Components.ToList();
            ViewBag.Module = _context.Modules.ToList();
            ViewBag.Developer = _context.Developers.ToList();
        }

        
        // GET: DailyDeveloperTaskLog
        public ActionResult Index()
        {
           
            return View();
        }
        public PartialViewResult getData()
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "ControllerName");
            ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId", "ServiceName");
            var model = _context.DailyDeveloperTaskLogs.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "ControllerName");
            ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId", "ServiceName");
            return PartialView("_addData", new DailyDeveloperTaskLog());

        }
        [HttpPost]
        public ActionResult addData(DailyDeveloperTaskLog daily)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                daily.CreatedByUserId = 1;
                daily.CreatedByUserName = "Suraz";
                daily.CreatedByUSerDate = DateTime.Now;
                _context.DailyDeveloperTaskLogs.Add(daily);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "";

            }
            else
            {
                ViewBag.Message = ModelState.GetModelStateErrors();
                result.IsSuccess = false;
                result.Message = "validation failed";
            }
            return Json(result);
        }
        [HttpGet]
        public PartialViewResult editData(int id)
        {
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList(), "ControllerId", "ControllerName");
            ViewBag.Services = new SelectList(_context.Services.ToList(), "ServiceId", "ServiceName");
            var model = _context.DailyDeveloperTaskLogs.FirstOrDefault(x => x.DailyDeveloperTaskLogId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(DailyDeveloperTaskLog comp)

        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {


                _context.Entry(comp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return Json(result);


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.DailyDeveloperTaskLogs.FirstOrDefault(x => x.DailyDeveloperTaskLogId == id);
            _context.DailyDeveloperTaskLogs.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
        [HttpGet]
        public ActionResult Bulk()
        {
            ViewBag.Components = _context.Components.ToList();
            ViewBag.ControllerDetails = _context.ControllerDetails.ToList();
            ViewBag.DailyDeveloperTaskLog =_context.DailyDeveloperTaskLogs.ToList();
            ViewBag.Developers = _context.Developers.ToList();
            ViewBag.Modules = _context.Modules.ToList();
            ViewBag.Services =_context.Services.ToList();
            ViewBag.Users = _context.Users.ToList();
            PopulateDopDown();
            var model = new List<DailyDeveloperTaskLogViewModel>();
            model.Add(new DailyDeveloperTaskLogViewModel());
            return View(model);
        }

    }
}
    