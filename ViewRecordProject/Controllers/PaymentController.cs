using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewRecordProject.Data;
using ViewRecordProject.Models;

namespace ViewRecordProject.Controllers
{
    public class PaymentController : Controller
    {
        private readonly dataContext _context;
        public PaymentController(dataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult PaymentList()
        {
                //select* from payment
                //INNER JOIN
                //StudentInClass
                //on payment.c_name = StudentInClass.c_name
                //and payment.Roll = StudentInClass.roll
                //inner join
                //Student
                //on StudentInClass.s_id = Student.s_id


                //var test = from s in _context.Student
                //           join m in _context.StudentInClass on s.s_id equals m.s_id
                //           join mo in _context.monthlyFee on m.c_name equals mo.c_id


                           var test= from p in _context.Payment
                            join s in _context.StudentInClass
                            on new { A = p.c_name, B = p.roll }equals new { A= s.c_name , B=s.roll} 
                            join st in _context.Student
                            on s.s_id equals st.s_id
                            
                           select new
                           {
                               p_id=p.id,
                               s_name=st.s_name,
                               c_name=s.c_name,
                               roll=s.roll,
                               fee=p.fee,
                               dateOfPayment=p.date_of_payment
                           };

                var model = new List<PaymentViewModel>();
                foreach (var i in test)
                {
                    var s = new PaymentViewModel();
                    s.p_id = i.p_id;
                    s.s_name = i.s_name;
                    s.c_name = i.c_name;
                    //s.Contect = i.Contact;
                    //s.Fee = i.Fee;
                    s.roll = i.roll;
                    s.fee = i.fee;
                    s.dateOfPayment = i.dateOfPayment;
                    model.Add(s);
                }
                return View(model);
                            
        }

        [HttpGet]
        public IActionResult Payment() {
            return View();
        }
        [HttpPost]
        public IActionResult PaymentForm(Payment model)
        {

            {
                using (var db = _context)
                {
                    Payment obj = new Payment
                    {
                        c_name = model.c_name,
                        roll = model.roll,
                        fee = model.fee,
                        date_of_payment = model.date_of_payment
                    };

                    db.Payment.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("PaymentList", "Payment");
                //return View();
            }
        }
    }
}