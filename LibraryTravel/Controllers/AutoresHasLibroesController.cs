using AutoMapper;
using LibraryTravel.BLL.DTOs;
using LibraryTravel.BLL.Repositories;
using LibraryTravel.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryTravel.Controllers
{
    public class AutoresHasLibroesController : Controller
    {
        // Llamamos el repositorio y el mapper
        readonly IAutoresHasLibrosRepository autoresHasLibrosRepository;
        readonly IMapper mapper;

        public AutoresHasLibroesController(IAutoresHasLibrosRepository autoresHasLibrosRepository, IMapper mapper)
        {
            this.autoresHasLibrosRepository = autoresHasLibrosRepository;
            this.mapper = mapper;
        }

        // GET: AutoresHasLibroes
        public async Task<IActionResult> Index()
        {
            var autoresHasLibros = autoresHasLibrosRepository.GetAllAsync().Result;
            var autoresHasLibrosDTO = autoresHasLibros.Select(x => mapper.Map<AutoresHasLibrosDTO>(x));
            return View(autoresHasLibrosDTO);
        }
       

        // GET: AutoresHasLibroes/Create
        public IActionResult Create()
        {           
            return View();
        }

        // POST: AutoresHasLibroes/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutoresId,LibrosIsbn")] AutoresHasLibrosDTO autoresHasLibrosDTO)
        {
            try
            {
                var autoresHasLibros = mapper.Map<AutoresHasLibro>(autoresHasLibrosDTO);
                if (autoresHasLibros != null)
                {
                    autoresHasLibros = autoresHasLibrosRepository.InsertAsync(autoresHasLibros).Result;
                    autoresHasLibrosDTO.Id = autoresHasLibros.Id;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        // GET: AutoresHasLibroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {          
            return View();
        }

        // POST: AutoresHasLibroes/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutoresId,LibrosIsbn")] AutoresHasLibrosDTO autoresHasLibrosDTO)
        {
            try
            {
                var autoresHasLibros = autoresHasLibrosRepository.GetByIdAsync(id).Result;
                if (autoresHasLibros == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autoresHasLibros != null)
                {
                    autoresHasLibros = mapper.Map<AutoresHasLibro>(autoresHasLibrosDTO);//objeto
                    autoresHasLibros = autoresHasLibrosRepository.UpdateAsync(autoresHasLibros).Result;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
            //ViewData["AutoresId"] = new SelectList(_context.Autores, "Id", "Id", autoresHasLibro.AutoresId);
            //ViewData["LibrosIsbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", autoresHasLibro.LibrosIsbn);
           
        }

        // GET: AutoresHasLibroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: AutoresHasLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var autor = autoresHasLibrosRepository.GetByIdAsync(id).Result;
                if (autor == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autor != null)
                {
                    await autoresHasLibrosRepository.DeleteAsync(id);
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }

        } 
        
    }
}
