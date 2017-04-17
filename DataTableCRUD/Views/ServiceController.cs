using DataTableCRUD.Helper;
using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Services
{
    [Authorize]
    public class ServiceController : BaseController
    {
        private readonly MyDatabaseEntities _context;
        public ServiceController()
        {
            _context = new MyDatabaseEntities();
        }
        // GET: ControllerDetails
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getData()
        {
            var model = _context.Services.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
           
            return PartialView("_addData", new Service());
        }
        [HttpPost]
        public ActionResult addData(Service service)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                service.CreatedByUserId = 1;
                service.CreatedByUserName = "Suraz";
                service.CreatedByUSerDate = DateTime.Now;
                _context.Entry(service).State = EntityState.Added;
                _context.SaveChanges();

            }
           
               
            return Json(result);
        }
        [HttpGet]
        public PartialViewResult editData(int id)
        {
          
            var model = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(Service service)

        {

            if (ModelState.IsValid)
            {


                _context.Entry(service).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Services.FirstOrDefault(x => x.ServiceId == id);
            _context.Services.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }
}


