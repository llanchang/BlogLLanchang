using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Blog
{
    public class LineaResumenPost
    {
        public int Id { get; set; }
        public string UrlSlug { get; set; }
        public string Titulo { get; set; }

        public string UrlImagen { get; set; }

        public string Subtitulo { get; set; }
        public DateTime FechaPost { get; set; }
        public string Autor { get; set; }
    }
}
