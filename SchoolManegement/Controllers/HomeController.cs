using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManegement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManegement.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext ac = new ApplicationContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = ac.Subjects.OrderBy(x => x.Num).ToList();
            return View(vm);
        }

        public ActionResult reverse(int id, bool p) 
        {
            var i = ac.Subjects.FirstOrDefault(x => x.Id == id);
            i.IsDone = p;
            ac.SaveChanges();
            return View("Index", ac.Subjects.OrderBy(x => x.Num).ToList());
        }

        public ActionResult Delete(int id)
        {
            var i = ac.Subjects.FirstOrDefault(x => x.Id == id);
            ac.Subjects.Remove(i);
            ac.SaveChanges();
            return View("Index", ac.Subjects.OrderBy(x => x.Num).ToList());
        }

        public ActionResult CSubj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CSubj(Subject s) 
        {
            s.IsDone = false;
            ac.Subjects.Add(s);
            ac.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
