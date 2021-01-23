    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    namespace WebApplication1.Controllers
    {
        public class HomeController : ApiController
        {
            [Route("api/TestAPI")]
            [HttpPost]
            public IHttpActionResult Post([FromBody]String test)
            {
                return Ok(string.Format("You passed {0}.", test));
            }
        }
    }
