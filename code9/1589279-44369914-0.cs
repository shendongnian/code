    using System;
    using Microsoft.AspNetCore.Mvc;
    
    namespace WebApplication4.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            [HttpPost]
            public void Post()
            {
                var name = HttpContext.Request.Form["name"].ToString();            
            }
    
            [HttpPost("post-my-request")]
            public void Post([FromBody]MyRequest myRequest)
            {
                var name = myRequest.name;
            }
        }
    
        public class MyRequest
        {
            public string name { get; set; }
        }
    }
