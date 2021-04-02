using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SubResync.Models;
using System.Text;
using SubResync.Repositories;
using SubResync.Services;

namespace SubResync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Upload : ControllerBase
    {

        [HttpPost, DisableRequestSizeLimit]

        public IActionResult UploadFile([FromServices] ISubResyncService service)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("resources", "files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var offset = Request.Form["offset"];
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    if(service.ApplyOffset(dbPath, Convert.ToDouble(offset)))
                    {
                        var url = $"http://localhost:53636/resources/files/{fileName}";
                        return Ok(new { url });
                    }
                    return StatusCode(403, "somethig wrong if the server.");

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: ${ex}");
            }
        }
        [HttpGet]

        public IActionResult List()
        {
            

            var folderName = Path.Combine("resources", "files");
            string[] PathName = Directory.GetFiles(folderName, "*.srt");

            
            return Ok(new { PathName });

        }
       
    }
}
