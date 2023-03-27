using AutoMapper;
using LibraryTravel.BLL.DTOs;
using LibraryTravel.BLL.Repositories;
using LibraryTravel.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryTravel.Controllers
{
    public class AutoresController : Controller
    {
       // Llamamos el repositorio y el mapper
        readonly IAutoresRepository autoresRepository;
        readonly IMapper mapper;       

        public AutoresController(IAutoresRepository autoresRepository, IMapper mapper)
        {
            this.autoresRepository = autoresRepository;
            this.mapper = mapper;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            var autor =  autoresRepository.GetAllAsync().Result;
            var customersDTO = autor.Select(x => mapper.Map<AutoresDTO>(x));
            return View (customersDTO);           
        }       

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] AutoresDTO autoreDTO)
        {
            try
            {
                var autor = mapper.Map<Autore>(autoreDTO);
                if (autor != null) 
                {
                    autor = autoresRepository.InsertAsync(autor).Result;
                    autoreDTO.Id = autor.Id;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }          

        }

        //GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {           
            return View();
        }

        // POST: Autores/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] AutoresDTO autoreDTO)
        {
            try
            {
                var autor = autoresRepository.GetByIdAsync(id).Result;
                if (autor == null) 
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autor != null) 
                {
                    autor = mapper.Map<Autore>(autoreDTO);//objeto
                    autor = autoresRepository.UpdateAsync(autor).Result;
                }  
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }           

        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var autor = autoresRepository.GetByIdAsync(id).Result;
                if (autor == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autor != null) 
                {
                    await autoresRepository.DeleteAsync(id);
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
