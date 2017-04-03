﻿using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    public class ComponentController : Controller
    {
        private readonly MyDatabaseEntities _context;
        public ComponentController()
        {
            _context = new MyDatabaseEntities();
        }
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
            return PartialView("_List",model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            ViewBag.Modules = new SelectList(_context.Modules.ToList(), "ModuleId", "ModuleName");
            ViewBag.Developers = new SelectList(_context.Developers.ToList(), "DeveloperId", "DeveloperName");
            return PartialView("_addData",new Component());
        }
        [HttpPost]
        public ActionResult addData(Component comp)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {
                comp.CreatedByUserId = 1;
                comp.CreatedByUserName = "Suraz";
                comp.CreatedByUSerDate = DateTime.Now;
                _context.Components.Add(comp);
                _context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "";

            }
            else {
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
            var model = _context.Components.FirstOrDefault(x => x.ComponentId== id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(Component comp)

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
            var model = _context.Components.FirstOrDefault(x => x.ComponentId == id);
            _context.Components.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }

    }
}