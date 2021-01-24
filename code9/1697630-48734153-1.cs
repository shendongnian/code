    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    
    namespace Server.Controllers {
     [Route("api/[controller]")]
     public class ValuesController: Controller {
      // GET api/values
      [HttpGet]
      public FileStreamResult GetTest() {
       var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World"));
       return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain")) {
        FileDownloadName = "test.txt"
       };
      }
     }
    }
