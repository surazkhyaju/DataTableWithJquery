using DataTableCRUD.Helper;
using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    public class FinalLogController : BaseController
    {
        private readonly MyDatabaseEntities _context;

       


        public FinalLogController()
        {
            _context = new MyDatabaseEntities();
        }
        // GET: FinalLog
        public ActionResult Index()
        {
            ViewBag.Components = new SelectList(_context.Components.ToList());
            ViewBag.ControllerDetails = new SelectList(_context.ControllerDetails.ToList());
            ViewBag.DailyDeveloperTaskLog = new SelectList(_context.DailyDeveloperTaskLogs.ToList());
            ViewBag.Developers = new SelectList(_context.Developers.ToList());
            ViewBag.Modules = new SelectList(_context.Modules.ToList());
            ViewBag.Services = new SelectList(_context.Services.ToList());
            ViewBag.Users = new SelectList(_context.Users.ToList());
           
            var data = _context.View2.ToList();
            return View(data);
        }

        
     
    }
}
