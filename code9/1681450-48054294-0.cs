    //removed prefix
    public class ResizeController : ApiController {
        //Matches POST api/resize/preserveAspectRatio
        [HttpPost, Route("api/resize/preserveAspectRatio")]
        public async Task<IHttpActionResult> resizePreserveAspectRatio() {
            //...removed for brevity
        }
    }
