using Dominio.Blog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Blog
{
    public class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos()
            : base("DefaultConnection")
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        public async Task GuardarCambios()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
