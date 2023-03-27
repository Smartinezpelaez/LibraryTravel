using AutoMapper;
using LibraryTravel.BLL.DTOs;
using LibraryTravel.BLL.Repositories;
using LibraryTravel.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryTravel.Controllers
{
    public class EditorialesController : Controller
    {
        // Llamamos el repositorio y el mapper
        readonly IEditorialesRepository editorialesRepository;
        readonly IMapper mapper;
       
        public EditorialesController(IEditorialesRepository editorialesRepository, IMapper mapper)
        {
            this.editorialesRepository = editorialesRepository;
            this.mapper = mapper;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index()
        {
            var editorial = editorialesRepository.GetAllAsync().Result;
            var editorialDTO = editorial.Select(x => mapper.Map<EditorialesDTO>(x));
            return View(editorialDTO);
        }
       
        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Sede")] EditorialesDTO editorialesDTO)
        {
            try
            {
                var editorial = mapper.Map<Editoriale>(editorialesDTO);
                if (editorial != null)
                {
                    editorial = editorialesRepository.InsertAsync(editorial).Result;
                    editorialesDTO.Id = editorial.Id;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {            
            return View();
        }

        // POST: Editoriales/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Sede")] EditorialesDTO editorialesDTO)
        {
            try
            {
                var editorial = editorialesRepository.GetByIdAsync(id).Result;
                if (editorial == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (editorial != null)
                {
                    editorial = mapper.Map<Editoriale>(editorialesDTO);//objeto
                    editorial = editorialesRepository.UpdateAsync(editorial).Result;
                }
                return RedirectToAction("Index");
                //return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = autoreDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var autor = editorialesRepository.GetByIdAsync(id).Result;
                if (autor == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (autor != null)
                {
                    await editorialesRepository.DeleteAsync(id);
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
