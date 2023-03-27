using System;
using System.Collections.Generic;

namespace LibraryTravel.DAL.Models
{
    public partial class AutoresHasLibro
    {
        public int Id { get; set; }
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autore Autores { get; set; } = null!;
        public virtual Libro LibrosIsbnNavigation { get; set; } = null!;
    }
}
