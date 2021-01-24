    [RoutePrefix("MyData")]
    public class MyDataController: ApiController {
    
        //GET MyData/GetOne
        [HttpGet]
        [Route("GetOne")]  
        public IHttpActionResult GetOne() { } 
    
        //GET MyData/GetTwo
        [HttpGet]
        [Route("GetTwo")]
        public IHttpActionResult GetTwo() { }
    }
