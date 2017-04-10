using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DataTableCRUD.Helper
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["currentUserId"] == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
            }


            base.OnActionExecuting(filterContext);
        }

    }
}