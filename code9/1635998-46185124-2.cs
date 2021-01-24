    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    
    namespace WebApplication.Controllers
    {
        [Route("api")]
        public class ValuesController : Controller
        {
            [HttpGet]
            [Route("values/{top}")]
            public IActionResult Get(int top)
            {
                // Generate dummy values
                var list = Enumerable.Range(0, DateTime.Now.Second)
                                     .Select(i => $"Value {i}")
                                     .ToList();
                list.Reverse();
    
                var result = new ObjectResult(list.Take(top))
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
    
                Response.Headers.Add("X-Total-Count", list.Count.ToString());
    
                return result;
            }
        }
    }
