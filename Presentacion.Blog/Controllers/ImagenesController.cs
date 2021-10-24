using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Presentacion.Blog.Helpers;
using Presentacion.Blog.Servicios;

namespace Presentacion.Blog.Controllers
{
    [Authorize]
    public class ImagenesController : Controller
    {
        private readonly SubirArchivoImagenServicio _imagenServicio;

        public ImagenesController()
            : this(new SubirArchivoImagenServicio())
        {
        }

        public ImagenesController(SubirArchivoImagenServicio imagenServicio)
        {
            _imagenServicio = imagenServicio;
        }


        [HttpPost]
        public ActionResult SubirImagen(HttpPostedFileBase upload, string ckEditorFuncNum, string ckEditor, string langCode)
        {
            if (upload == null)
                return Content("Selecciona una imagen");

            if (!upload.FileName.TerminaConUnaExtensionDeImagenValida())
                return Content("Selecciona una archivo jpg, gif o png");

            WebImage imagen = upload.ToWebImage();

            string filename = _imagenServicio.SubirImagen(imagen, dimensionMaxima: 1000);

            string respuestaCkEditor = CrearRespuestaParaCkEditor(filename, ckEditorFuncNum);

            return Content(respuestaCkEditor);
        }

        private string CrearRespuestaParaCkEditor(string filename, string ckEditorFuncNum)
        {
            if (String.IsNullOrEmpty(filename))
            {
                return CrearMensageErrorParaCkEditor(ckEditorFuncNum, "Error: No se ha guardado la imagen.");
            }

            var url = (filename).GenerarUrlImagen();

            return CrearRespuestaCorrectaParaCkEditor(ckEditorFuncNum, url);
        }

        private string CrearMensageErrorParaCkEditor(string ckEditorFuncNum, string message)
        {
            var url = Request.Url.GetLeftPart(UriPartial.Authority);
            return @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum + ", \"" +
                   url + "\", \"" + message + "\");</script></body></html>";
        }

        private string CrearRespuestaCorrectaParaCkEditor(string ckEditorFuncNum, string url)
        {
     
            return @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + ckEditorFuncNum +
                         ", \"" + url + "\", function() { " +

            "var element, dialog = this.getDialog();" +
            "if (dialog.getName() == 'image')" +
            "{" +

                "element = dialog.getContentElement('advanced', 'txtGenClass');" +
                "if (element)" +
                    "element.setValue('img-responsive');" +

            "}" +
            "});</script></body></html>";
        }
    }

}