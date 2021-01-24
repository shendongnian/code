    [RoutePrefix("api/Image")]
    public class ImageController : ApiController {        
        [HttpPost]
        [Route("Upload")] // Matches POST api/Image/Upload
        public IHttpActionResult Upload()
        {
            return Ok("I am working");
        }
    }
