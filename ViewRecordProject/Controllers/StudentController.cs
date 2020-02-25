using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewRecordProject.Models;
using ViewRecordProject.Data;

namespace ViewRecordProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly dataContext _context;
        public StudentController(dataContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var test = from s in _context.Student
                       join m in _context.StudentInClass on s.s_id equals m.s_id
                       join mo in _context.monthlyFee on m.c_name equals mo.c_id
                       
                       select new
                       {
                           Id = s.s_id,
                           Class = m.c_name,
                           Roll = m.roll,
                           Name = s.s_name,
                           Address = s.s_address,
                           //Contact = s.Contect
                           MonthlyFee=mo.Fee
                       };

            var model = new List<Students>();
            foreach (var i in test)
            {
                var s = new Students();
                s.Id = i.Id;
                s.Name = i.Name;
                s.Address = i.Address;
                //s.Contect = i.Contact;
                //s.Fee = i.Fee;
                s.Roll = i.Roll;
                s.Fee = i.MonthlyFee;
                s.Class = i.Class;
                model.Add(s);
            }
            return View(model);
            //return View();
            
        }

        [HttpGet]
        public IActionResult addStudent() {
            return View();
        }

        [HttpPost]
        public IActionResult addStudent(Students model)
        {

            {
                using (var db = _context)
                {
                    Student student = new Student
                    {
                        s_id = model.Id,
                        s_name = model.Name,
                        s_address = model.Address
                    };
                    StudentInClass sincl = new StudentInClass
                    {
                        c_name = model.Class,
                        s_id = model.Id,
                        roll = model.Roll
                    };
                    db.StudentInClass.Add(sincl);
                    db.Student.Add(student);
                    db.SaveChanges();
                }
                return RedirectToAction("List", "Student");
            }
    }
        
        public IActionResult deleteStudent(int id) {

        

            using (var db = _context)
            {
                //db.StudentInClass.Remove(db.StudentInClass.Find(id));
                db.Student.Remove(db.Student.Find(id));

                db.SaveChanges();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
