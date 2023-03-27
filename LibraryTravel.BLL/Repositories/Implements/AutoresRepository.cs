using CodinJuego.BLL.Repositories.Implements;
using LibraryTravel.DAL.Models;


namespace LibraryTravel.BLL.Repositories.Implements
{
    public  class AutoresRepository : GenericRepository<Autore>, IAutoresRepository
    {
        private readonly BrowserTravelContext context;
        public AutoresRepository(BrowserTravelContext context) : base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var autor = await GetByIdAsync(id);

            if (autor == null) throw new Exception("The entity is null.");
            //if (context.Autores.Any(x => x.Id == id)) throw new Exception("Foreign Key Accounts.");

            context.Autores.Remove(autor);
            await context.SaveChangesAsync();
        }

    }
}
