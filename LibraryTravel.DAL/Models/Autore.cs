using System;
using System.Collections.Generic;

namespace LibraryTravel.DAL.Models
{
    public partial class Autore
    {
        public Autore()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
