using DataTableCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DataTableCRUD.Controllers
{
  
    public class LoginController : Controller
    {
        private readonly MyDatabaseEntities _context;
        public LoginController()
        {
            _context = new MyDatabaseEntities();
        }
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            var model = _context.Users.FirstOrDefault(x =>x.UserName==u.UserName && x.Password==u.Password);
            if (model != null)
            {
                Session.Add("currentUserId", model.UserId);
                FormsAuthentication.SetAuthCookie(u.UserName,false);
                return RedirectToAction("Main", "Home");

            }
            else
            {
                ViewBag.message = "please enter username and password correctly ";
            }
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Home");


        }



    }
}
