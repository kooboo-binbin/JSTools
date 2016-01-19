using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return Content("Hello");
        }

        public ActionResult EX1()
        {
            throw new Exception("EX!");
            return Content("Hello");
        }

        public ActionResult Error()
        {
            Response.StatusCode = 500;
            return Content("Error");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return Content("Not found");
        }

    }
}