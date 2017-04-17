using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;


namespace DataTableCRUD.Helper
{
    public static class Extension
    {
        public static string GetModelStateErrors(this System.Web.Mvc.ModelStateDictionary modelState)
        {
            var result = string.Empty;
            foreach (System.Web.Mvc.ModelState modelStateValue in modelState.Values)
            {
                foreach (System.Web.Mvc.ModelError error in modelStateValue.Errors)
                {
                    result += error.ErrorMessage;
                }
            }
            return result;
        }
      
    }
}
