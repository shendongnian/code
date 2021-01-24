    [RoutePrefix("api/resize")]
    public class ResizeController : ApiController {
        //Matches POST api/resize/preserveAspectRatio
        [HttpPost, Route("preserveAspectRatio")]
        public async Task<IHttpActionResult> resizePreserveAspectRatio() {
            //...removed for brevity
        }
    }
