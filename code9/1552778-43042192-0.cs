    public class SmartlingController : BaseApiController {
        //POST api/smartling/ProcessSmartlingTranslation
        [Route("api/smartling/ProcessSmartlingTranslation")]
        [VersionedRoute("api/smartling/ProcessSmartlingTranslation", 1)]
        [ResponseType(typeof(HttpResponseMessage))]
        [HttpPost]
        public IHttpActionResult ProcessSmartlingTranslation(HttpRequestMessage request)  {
           //some business logic
        }
    }
    public class CommentsController : BaseApiController {
        //POST api/comments/GetAndPostBlogComments
        [Route("api/comments/GetAndPostBlogComments")]
        [VersionedRoute("api/comments/GetAndPostBlogComments", 1)]
        [ResponseType(typeof(HttpResponseMessage))]
        [HttpPost]
        public IHttpActionResult GetAndPostBlogComments([FromBody] BlogAndStoryComment comment) {
           //some business logic
        }
        //POST api/comments/GetAndPostStoryComments
        [Route("api/comments/GetAndPostStoryComments")]
        [VersionedRoute("api/comments/GetAndPostStoryComments", 1)]
        [ResponseType(typeof(HttpResponseMessage))]
        [HttpPost]
        public IHttpActionResult GetAndPostStoryComments([FromBody] BlogAndStoryComment comment) {
           //some business logic
        }
    }
