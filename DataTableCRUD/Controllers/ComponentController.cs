using DataTableCRUD.Helper;
using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    [Authorize]
    public class ComponentController : BaseController
    {

        private readonly MyDatabaseEntities _context;
        public ComponentController()
        {
            _context = new MyDatabaseEntities();
        }
        [Authorize(Roles = "Admin")]
        // GET: Component
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult getData()
        {
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            var model = _context.Components.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            return PartialView("_addData", new Component());
        }
        [HttpPost]
        public ActionResult addData(Component comp)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                {
                    _context.Entry(comp).State = EntityState.Added;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

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
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            var model = _context.Components.FirstOrDefault(x => x.ComponentId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(Component comp)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(comp).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Components.FirstOrDefault(x => x.ComponentId == id);
            _context.Components.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }

    }
}