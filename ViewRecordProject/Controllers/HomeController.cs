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
    public class HomeController : Controller
    {
        private readonly dataContext _context;
        public HomeController(dataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login p)
        {
            var i = _context.Login2.Where(x => x.username == p.username && x.password == p.password).FirstOrDefault();
            if (i == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("List","Student");
            }
        }

        public IActionResult studentDetails()
        {
            var test = _context.Student.FirstOrDefault();

            Students model = new Students
            {
                Id = test.s_id,
                Name = test.s_name

            };

            return View(model);

        }

        
 
        public IActionResult About()
        {
            var test = _context.Faculties;
            var model = new List<Faculty>();
            foreach (var i in test)
            {
                var s = new Faculty();
                s.id = i.id;
                s.name = i.name;
                s.depertment = i.depertment;
                model.Add(s);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Contact()
        {
            var test = _context.Login2;
            var model = new List<Login>();
            foreach (var i in test)
            {
                var s = new Login();
                s.id = i.id;
                s.username = i.username;
                s.password = i.password;
                model.Add(s);
            }



            return View(model);
        }

        [HttpPost]
        public IActionResult addLoginAccesser(Login model)
        {

            {
                using (var db = _context)
                {
                    Login login = new Login
                    {
                        id = model.id,
                        username = model.username,
                        password = model.password

                    };
                    db.Login2.Add(login);
                    db.SaveChanges();
                }

                return RedirectToAction("Contact");
                //return Content($"hello {model.username}. your password is {model.password}");
            }
                
        }

        [HttpGet]
        public IActionResult addLoginAccesser()
        {
            return View();
        }

       
    }
}

