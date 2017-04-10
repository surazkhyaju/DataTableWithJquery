using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableCRUD.Helper
{
    public class ListItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class DropdownHelper
    {
        public static List<ListItem> UserTypes
        {
            get
            {
                return new List<ListItem>() {
                    new ListItem() {
                        Value="Admin",
                        Text="Admin"
                    },
                    new ListItem()
                    {
                        Value="Developer",
                        Text = "Developer"
                    }
                };
            }
        }

        public static SelectList UserTypeSelectList
        {
            get
            {
                return new SelectList(UserTypes, "Value", "Text");
            }
        }
        public static List<ListItem>ServiceTypes
        {
            get
            {
                return new List<ListItem>() {
                    new ListItem() {
                        Value="Started",
                        Text="Started"
                    },
                    new ListItem()
                    {
                        Value="InProgress",
                        Text = "InProgress"
                    },
                      new ListItem() {
                        Value="Finished",
                        Text="Finished"
                    },
                    new ListItem()
                    {
                        Value="OverViewed",
                        Text = "Overviewed"
                    }
                };

            }
        }
        public static SelectList ServiceTypeSelectList
        {
            get
            {
                return new SelectList(ServiceTypes, "Value", "Text");
            }
        }
    }
}