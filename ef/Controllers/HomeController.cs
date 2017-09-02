using ef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ef.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (TestContext db = new TestContext())
            {
                await db.MainTables.ToListAsync();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}