using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ViewRecordProject.Models
{
    public class Student
    {
        [Key]
        public int s_id { get; set; }
        public String s_name { get; set; }
        public String s_address { get; set; }
        public String s_DOB { get; set; }


    }
}
