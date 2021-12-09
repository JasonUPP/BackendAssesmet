using Assesmet.Context;
using Assesmet.Models;
using Assesmet.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Assesmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly AtosContext context;
        private readonly Response response = new();

        public LanguageController(AtosContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await context.Languages.ToListAsync());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Language language)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Languages.Add(language);
                    await context.SaveChangesAsync();
                    return Json(response.Success());
                }
                catch (Exception e) { return Json(response.Fail(e.Message)); }
            }
            return Json(response.Fail("Modelo Invalido"));
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(language);
                    await context.SaveChangesAsync();
                    return Json(response.Success());
                }
                catch (Exception e) { return Json(response.Fail(e.Message)); }
            }
            return Json(response.Fail("Modelo Invalido"));
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Language language = await context.Languages.FindAsync(id);
                context.Languages.Remove(language);
                await context.SaveChangesAsync();
                return Json(response.Success());
            }
            catch (Exception e) { return Json(response.Fail(e.Message)); }
        }
    }
}