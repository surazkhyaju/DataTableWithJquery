﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataTableCRUD.Models
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {

    }
    


        public class EmployeeMetadata

        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide First Name ")]
            public string FirstName { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide First Name ")]
            public string LastName { get; set; }

        }
    
}