using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentacion.Blog.ViewModel.Post
{
    public class PublicarPost
    {

        public PublicarPost()
        {

        }
        public PublicarPost(Dominio.Blog.Post  post) : this()
        {
            this.InjectFrom(post);
        }
        public int Id { get; set; }


        [Display(Name = "Url del post")]
        [Required(ErrorMessage = "Escribe una url")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de {1} dígitos")]
        public string UrlSlug
        {
            get;
            set;
        }

        [Display(Name = @"Fecha")]
        [Required(ErrorMessage = @"Escribe una fecha")]
        public DateTime FechaPost { get; set; }

        [Display(Name = "Rss Atom")]
        public bool EsRssAtom { get; set; }

        [Display(Name = "Fecha de publicación")]
        [Required(ErrorMessage = "Escribe una fecha")]
        public DateTime FechaPublicacion { get; set; }


    }
}
