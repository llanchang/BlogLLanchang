using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Blog
{
    public class AsignadorTags
    {
        private readonly ITagRepositorio _tagRepositorio;
        private IEntidadConTags _entidad;

        public AsignadorTags(ITagRepositorio tagRepositorio)
        {
            _tagRepositorio = tagRepositorio;
        }

        public void AsignarTags(IEntidadConTags entidad, List<string> listaTags)
        {
            _entidad = entidad;

            var tagsPorEliminarDeEntidad = DetecatarTagsPorEliminarDeEntidad(listaTags);

            var tagsPorAñadirAEntidad = DetectarNuevosTagsPorAñadirAEntidad(listaTags);

            EliminarTags(tagsPorEliminarDeEntidad);

            AñadirTags(tagsPorAñadirAEntidad);
        }

        private void AñadirTags(IEnumerable<string> tagsPorAñadir)
        {
            foreach (var tagPorAñadir in tagsPorAñadir)
            {
                var tag = CrearORecuperarTag(tagPorAñadir);
                _entidad.Tags.Add(tag);
            }
        }

        private Tag CrearORecuperarTag(string tagPorAñadir)
        {
            tagPorAñadir = tagPorAñadir.Trim();
            var tag = _tagRepositorio.RecuperarTagPorNombre(tagPorAñadir);

            if (tag == null)
            {
                tag = new Tag
                {
                    Nombre = tagPorAñadir,
                    UrlSlug = GeneradorUrlSlug.GenerateSlug(tagPorAñadir)
                };
            }

            return tag;
        }

        private void EliminarTags(List<Tag> tagsPorEliminar)
        {
            while (tagsPorEliminar.Any())
            {
                var tag = tagsPorEliminar.First();

                _entidad.Tags.Remove(tag);
                tagsPorEliminar.Remove(tag);
            }
        }

        private IEnumerable<string> DetectarNuevosTagsPorAñadirAEntidad(List<string> listaTags)
        {
            return listaTags.Except(_entidad.Tags.Select(t => t.Nombre));
        }

        private List<Tag> DetecatarTagsPorEliminarDeEntidad(List<string> listaTags)
        {
            return _entidad.Tags.Where(m => !listaTags.Contains(m.Nombre)).ToList();
        }
    }
}