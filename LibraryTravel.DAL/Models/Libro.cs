using System;
using System.Collections.Generic;

namespace LibraryTravel.DAL.Models
{
    public partial class Libro
    {
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

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
