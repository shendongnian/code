    [ApiVersion("1")]
    [Route("api/v{api-version:apiVersion}/")]
    public class AlbumController : Controller
    {
       [HttpGet("album/{id}", Name = "GetAlbum")]
        public IActionResult GetById(long id)
        {
             //some code
        }
    
        [HttpGet("album", Name = "GetAlbums")]
        public IActionResult GetAll()
        {
            //some code
        }
        [HttpGet]
        [Route("executors/{executorId}/albums")]
        public IActionResult GetAlbumsByExecutorId(long executorId)
        {
             return new ObjectResult(_service.GetAlbumsByExecutorId(executorId));
        }
    }
