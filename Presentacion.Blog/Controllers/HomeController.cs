using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Administracion de Blog";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "En espera de ingresar a laboral WIDOLL";

            return View();
        }
    }
}