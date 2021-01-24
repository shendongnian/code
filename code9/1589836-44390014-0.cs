    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    
    public class TestController : Controller
    {
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://apiaddress", HttpCompletionOption.ResponseHeadersRead); // this ensures the response body is not buffered
                
                using (var stream = await response.Content.ReadAsStreamAsync()) 
                {
                    return File(stream, "application/pdf");
                }
            }
        }
    }
