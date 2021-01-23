    using System;    // for Console.WriteLine
    using Microsoft.AspNetCore.Mvc;  // for Controller, [Route], [HttpPost], [FromBody], JsonResult and Json 
    
    namespace ApiCall.Controllers
    {
        [Route("api/[controller]")]
        public class FetchController : Controller
        {
            // POST api/values
            [HttpPost]
            public JsonResult Post([FromBody]object loginParam)
            {
                Console.WriteLine(loginParam);
                return Json(loginParam);
            }
    
        }
    }
