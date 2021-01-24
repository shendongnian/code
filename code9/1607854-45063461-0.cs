    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    
    namespace DemoWebCore.Controllers
    {
        [Route("api/[controller]")]
        public class FilesController : Controller
        {
            // GET api/files/sample.png
            [HttpGet("{fileName}")]
            public async Task<ActionResult> Get(string fileName)
            {
                var cd = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline")
                {
                    FileName = "Excel.xlsx"
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());
                StreamContent stream = YOUR_STREAM_SOURCE
                byte[] content = await stream.ReadAsByteArrayAsync();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }
    }
