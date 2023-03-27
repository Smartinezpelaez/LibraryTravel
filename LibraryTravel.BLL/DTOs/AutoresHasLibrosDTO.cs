using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.DTOs
{
    public class AutoresHasLibrosDTO
    {

        public int Id { get; set; }
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }

        public virtual Autore Autores { get; set; } = null!;
        public virtual Libro LibrosIsbnNavigation { get; set; } = null!;
    }
}
