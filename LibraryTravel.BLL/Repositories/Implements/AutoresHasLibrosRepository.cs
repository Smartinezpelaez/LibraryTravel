using CodinJuego.BLL.Repositories.Implements;
using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.Repositories.Implements
{
    public class AutoresHasLibrosRepository : GenericRepository<AutoresHasLibro>, IAutoresHasLibrosRepository
    {
        private readonly BrowserTravelContext context;
        public AutoresHasLibrosRepository(BrowserTravelContext context) : base(context)
        {
            this.context = context;
        }
        public new async Task DeleteAsync(int id)
        {
            var autoresHaslibros = await GetByIdAsync(id);

            if (autoresHaslibros == null) throw new Exception("The entity is null.");
           // if (context.AutoresHasLibros.Any(x => x.Id == id)) throw new Exception("Foreign Key Accounts.");

            context.AutoresHasLibros.Remove(autoresHaslibros);
            await context.SaveChangesAsync();
        }

    }
}
