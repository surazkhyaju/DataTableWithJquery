﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
            // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
    }
}