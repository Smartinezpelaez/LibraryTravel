using AutoMapper;
using LibraryTravel.BLL.DTOs;
using LibraryTravel.BLL.Repositories;
using LibraryTravel.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryTravel.Controllers
{
    public class LibroesController : Controller
    {
        // Llamamos el repositorio y el mapper
        readonly ILibrosRepository librosRepository;
        readonly IMapper mapper;

        public LibroesController(ILibrosRepository librosRepository, IMapper mapper)
        {
            this.librosRepository = librosRepository;
            this.mapper = mapper;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            var libros = librosRepository.GetAllAsync().Result;
            var librosDTO = libros.Select(x => mapper.Map<LibrosDTO>(x));
            return View(librosDTO);
        }
        

        // GET: Libroes/Create
        public IActionResult Create()
        {
           // ViewData["EditorialesEntityId"] = new SelectList(_context.Editoriales, "Id", "Id");
            return View();
        }

        // POST: Libroes/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,EditorialesId,Titulo,Sipnosis,NPaginas,EditorialesEntityId")] LibrosDTO librosDTO)
        {
            try
            {
                var libros = mapper.Map<Libro>(librosDTO);
                if (libros != null)
                {
                    libros = librosRepository.InsertAsync(libros).Result;
                    librosDTO.Isbn = libros.Isbn;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            //ViewData["EditorialesEntityId"] = new SelectList(_context.Editoriales, "Id", "Id", libro.EditorialesEntityId);
            return View();
        }

        // POST: Libroes/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Isbn,EditorialesId,Titulo,Sipnosis,NPaginas,EditorialesEntityId")] LibrosDTO librosDTO)
        {
            try
            {
                var libros = librosRepository.GetByIdAsync(id).Result;
                if (libros == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (libros != null)
                {
                    libros = mapper.Map<Libro>(librosDTO);//objeto
                    libros = librosRepository.UpdateAsync(libros).Result;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        { 
            return View();
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var autor = librosRepository.GetByIdAsync(id).Result;
                if (autor == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autor != null)
                {
                    await librosRepository.DeleteAsync(id);
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
