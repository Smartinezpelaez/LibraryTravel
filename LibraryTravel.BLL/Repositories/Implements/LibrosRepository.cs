using CodinJuego.BLL.Repositories.Implements;
using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.Repositories.Implements
{
    public class LibrosRepository : GenericRepository<Libro>, ILibrosRepository
    {
        private readonly BrowserTravelContext context;
        public LibrosRepository(BrowserTravelContext context) : base(context)
        {
            this.context = context;
        }
        public new async Task DeleteAsync(int id)
        {
            var libros = await GetByIdAsync(id);

            if (libros == null) throw new Exception("The entity is null.");
            // if (context.Libros.Any(x => x.Isbn == id)) throw new Exception("Foreign Key Accounts.");
           

            context.Libros.Remove(libros);
            await context.SaveChangesAsync();
        }

    }
}
