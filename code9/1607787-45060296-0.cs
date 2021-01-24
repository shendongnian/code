    using System;
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
            public async Task<string> Get(string fileName)
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(
                         "https://i.stack.imgur.com/hM8Ah.jpg?s=48&g=1");
                    byte[] content = await response.Content.ReadAsByteArrayAsync();
                    return "data:image/png;base64," + Convert.ToBase64String(content);
                }
            }
        }
    }
