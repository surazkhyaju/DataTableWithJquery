using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTableCRUD.Models.ViewModel
{
    public class DailyDeveloperTaskLogViewModel
    {
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }
        public int ComponentId { get; set; }
        public int ControllerId { get; set; }
        public String ControllerName { get; set; }
        public int ServiceId { get; set; }
        public String ServiceName { get; set; }
        public String Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String View { get; set; }
        public String JSFileName { get; set; }
        public String Remarks { get; set; }
    }
}