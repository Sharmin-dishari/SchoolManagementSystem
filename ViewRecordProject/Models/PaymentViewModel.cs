using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewRecordProject.Models
{
    public class PaymentViewModel
    {
        public int p_id { get; set; }
        public String s_name { get; set; }
        public int c_name { get; set; }
        public int roll { get; set; }
        public int fee { get; set; }
        public String dateOfPayment { get; set; }
    }
}
