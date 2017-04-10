
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
    public class UserController :BaseController
    {
        private readonly MyDatabaseEntities _context;
        public UserController()
        {
            _context = new MyDatabaseEntities();
        }
        [Authorize(Roles ="Admin")]
        // GET: USer
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult getData()
        {
            var model = _context.Users.ToList();
            return PartialView("_List", model);
        }
        [HttpGet]
        public PartialViewResult addData()
        {
            return PartialView("_addData", new User());
        }
        [HttpPost]
        public ActionResult addData(User user)
        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {

                _context.Users.Add(user);
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
            var model = _context.Users.FirstOrDefault(x => x.UserId == id);
            return PartialView("_editData", model);
        }
        [HttpPost]
        public ActionResult editData(User user)

        {
            var result = new JsonResult();
            if (ModelState.IsValid)
            {


                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return Json(result);


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var model = _context.Users.FirstOrDefault(x => x.UserId == id);
            _context.Users.Remove(model);
            _context.SaveChanges();
            return Json(new { Issuccess = true });
        }
    }
}

