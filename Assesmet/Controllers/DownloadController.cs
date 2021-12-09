using Assesmet.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Assesmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {        

        [HttpPost]
        [Route("Download")]
        public IActionResult Download(string url, string fileName)
        {
            Response response = new();
            try
            {
                using WebClient webClient = new();
                webClient.DownloadFileAsync(
                    new Uri(url),  //link to file
                    $"D:\\Documentos\\Examen de Atos\\{fileName}" //path to save
                 );
                return Json(response.Success());
            }
            catch (Exception e) { return Json(response.Fail(e.Message)); }            
        }

    }
}
