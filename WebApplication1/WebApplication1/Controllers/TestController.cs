using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Work work = new Work();
            try
            {
                var users = work.Users.GetUsers();
            }
            catch (Exception ex) { }
            return View();
        }
    }
}