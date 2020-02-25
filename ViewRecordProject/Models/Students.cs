using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewRecordProject.Models
{
    public class Students
    {
        public int Id { get; set; }
        
        public string  Name { get; set; }
       
        public string Address { get; set; }
        public int Fee { get; set; }
        public string Contect { get; set; }
        public int Roll { get; set; }
        public int Class { get; set; }
        public String Bdate { get; set; }
    }
}
