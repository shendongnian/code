    [MyAuthorizationProvider]
        public class MyController : ApiController
      {
        [Route("")]
        [Authorize]
        public async Task<IHttpActionResult> Get() {}
      }
