        public class MyController : ApiController
      {
        [Route("")]
        [MyAuthorizationProvider]
        public async Task<IHttpActionResult> Get() {}
      }
