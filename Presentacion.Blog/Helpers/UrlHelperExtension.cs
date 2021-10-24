using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Blog.Helpers
{
    public static class UrlHelperExtension
    {
        public static string RutaUrlBlogPost(this UrlHelper url, DateTime fechaPost, string urlSlug)
        {
            var result = url.RouteUrl("BlogPost",
                new
                {
                    dia = fechaPost.Day,
                    mes = fechaPost.Month,
                    anyo = fechaPost.Year,
                    urlSlug
                }, url.RequestContext.HttpContext.Request.Url.Scheme);

            return result;
        }
    }
}