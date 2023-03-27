using AutoMapper;
using LibraryTravel.DAL.Models;

namespace LibraryTravel.BLL.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Autore, AutoresDTO>().ReverseMap();
            CreateMap<Editoriale, EditorialesDTO>().ReverseMap();
            CreateMap<Libro, LibrosDTO>().ReverseMap();
            CreateMap<AutoresHasLibro, AutoresHasLibrosDTO>().ReverseMap();
        }

    }


}
