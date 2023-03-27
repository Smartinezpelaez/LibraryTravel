using CodinJuego.BLL.Repositories.Implements;
using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.Repositories.Implements
{
    public class EditorialesRepository : GenericRepository<Editoriale>, IEditorialesRepository
    {
        private readonly BrowserTravelContext context;
        public EditorialesRepository(BrowserTravelContext context) : base(context)
        {
            this.context = context;
        }
        public new async Task DeleteAsync(int id)
        {
            var editoriales = await GetByIdAsync(id);

            if (editoriales == null) throw new Exception("The entity is null.");
           // if (context.Editoriales.Any(x => x.Id == id)) throw new Exception("Foreign Key Accounts.");

            context.Editoriales.Remove(editoriales);
            await context.SaveChangesAsync();
        }

    }
}
