using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Blog
{
    public interface IEntidadConTags
    {
        ICollection<Tag> Tags { get; set; }
    }
}
