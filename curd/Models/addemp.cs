using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace curd.Models
{
    public class addemp
    {
        [Required]
        public int empid { get; set; }

        [Required]
        public string empname { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string address { get; set; }
    }
}