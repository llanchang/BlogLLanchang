using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Presentacion.Blog.Helpers
{
    public static class ImagenHelper
    {
        public static WebImage ToWebImage(this HttpRequestBase request)
        {
            if (request.Files.Count == 0) return null;

            var postedFile = request.Files[0];
            var image = new WebImage(postedFile.InputStream)
            {
                FileName = postedFile.FileName
            };
            return image;
        }

        public static bool TerminaConUnaExtensionDeImagenValida(this string nombreArchivo)
        {
            return nombreArchivo.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                nombreArchivo.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                nombreArchivo.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) ||
                nombreArchivo.EndsWith(".JPG", StringComparison.CurrentCultureIgnoreCase) ||
                nombreArchivo.EndsWith(".GIF", StringComparison.CurrentCultureIgnoreCase) ||
                nombreArchivo.EndsWith(".PNG", StringComparison.CurrentCultureIgnoreCase);
        }

        public static WebImage ToWebImage(this HttpPostedFileBase postedFile)
        {
            if (postedFile == null) return null;

            var image = new WebImage(postedFile.InputStream)
            {
                FileName = postedFile.FileName
            };
            return image;
        }


        public static string GenerarUrlImagen(this string relativefilepath)
        {
            return string.Format("{0}/{1}",
                WebConfigParametro.UrlRaizImagenes,
                relativefilepath);
        }

        public static string GenerarUrlImagen(this string relativefilepath, string folderPath)
        {

           // string destino = Path.Combine(Application.StartupPath, String.Format(@"C:\Users\ti1\Documents\prueba\{0}", Path.GetFileName(ofd.FileName)));
            //File.Copy(ofd.FileName, destino);

            return $"{WebConfigParametro.UrlRaizImagenes}{folderPath}{relativefilepath}";

            
        }


    }
}