using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewRecordProject.Models
{
    public class ClassInfo
    {
        [Key]
        public int c_id { get; set; }
        public int c_name { get; set; }
    }
}
