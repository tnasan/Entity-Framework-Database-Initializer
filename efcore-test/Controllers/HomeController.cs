using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ef_test.Data;
using ef_test.Models;

namespace ef_test.Controllers
{
    public class HomeController : Controller
    {
        private TestContext db;

        public HomeController(TestContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            db.MainTables.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
