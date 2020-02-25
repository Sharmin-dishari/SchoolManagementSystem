using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewRecordProject.Models
{
    public class Payment
    {
        
        public int id { get; set; }
        public int c_name { get; set; }
        public int roll { get; set; }
        public int fee { get; set; }
        public String date_of_payment { get; set; }
    }
}
