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
    public class CountriesController : Controller
    {
        private readonly AtosContext context;
        private readonly Response response = new();

        public CountriesController(AtosContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await context.Countries.ToListAsync());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Countries country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Countries.Add(country);
                    await context.SaveChangesAsync();
                    return Json(response.Success());
                }
                catch (Exception e) { return Json(response.Fail(e.Message)); }
            }
            return Json(response.Fail("Modelo Invalido"));
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Countries country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(country);
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
                Countries country = await context.Countries.FindAsync(id);
                context.Countries.Remove(country);
                await context.SaveChangesAsync();
                return Json(response.Success());
            }
            catch (Exception e) { return Json(response.Fail(e.Message)); }
        }

    }
}