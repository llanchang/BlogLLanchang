using Dominio.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Blog
{
    public class TagRepositorio : ITagRepositorio
    {
        private readonly ContextoBaseDatos _db;

        public TagRepositorio(ContextoBaseDatos contexto)
        {
            _db = contexto;
        }

        public Tag RecuperarTagPorNombre(string nombreTag)
        {
            return _db.Tags.FirstOrDefault(m => m.Nombre.ToLower() == nombreTag.ToLower());
        }
    }
}
