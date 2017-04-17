using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataTableCRUD.Models.ViewModel
{
    public class DailyDeveloperTaskLogViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
       
        public string Date { get; set; }
        public int ModuleId { get; set; }
        public int ComponentId { get; set; }
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string View { get; set; }
        public string JSFileName { get; set; }
        public string Remarks { get; set; }

    }
}