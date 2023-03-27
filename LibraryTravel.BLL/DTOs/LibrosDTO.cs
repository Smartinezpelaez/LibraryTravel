using LibraryTravel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTravel.BLL.DTOs
{
    public class LibrosDTO
    {

        public int Isbn { get; set; }
        public int EditorialesId { get; set; }
        public string? Titulo { get; set; }
        public string? Sipnosis { get; set; }
        public string? NPaginas { get; set; }
        public int? EditorialesEntityId { get; set; }

        public virtual Editoriale? EditorialesEntity { get; set; }
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }

    }
}
