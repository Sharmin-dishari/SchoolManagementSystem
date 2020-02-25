using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ViewRecordProject.Models
{
    public class Section
    {
        [Key]
        public int sec_id { get; set; }
        public String sec_name { get; set; }
    }
}
