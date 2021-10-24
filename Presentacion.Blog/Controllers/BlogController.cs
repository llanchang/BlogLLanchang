using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dominio.Blog;
using Infraestructura.Blog;
using Presentacion.Blog.Controllers;

namespace Presentacion.Blog.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Detalles(int dia, int mes, int anyo, string urlSlug)
        {
            return RedirectPermanent(@"/" + urlSlug);
        }
       
      
    }

}