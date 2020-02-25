using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewRecordProject.Models
{
    public class monthlyFee
    {
        [Key]
        public int c_id { get; set; }
        public int Fee { get; set; }
    }
}
