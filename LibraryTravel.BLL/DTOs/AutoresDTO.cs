using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.DTOs
{
    public class AutoresDTO
    {
        
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
