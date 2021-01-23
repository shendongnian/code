    public class BizAuthController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public __BizAuthModel Register([FromBody] __BizAuthModel authInfo)
        {
            if (ModelState.IsValid)
            {
              //... do whatever
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    
        [HttpPost]
        [Route("Login")]
        public __BizAuthModel Login([FromBody] __BizAuthModel authInfo)
        {
            if (ModelState.IsValid)
            {
              //... do whatever
            }
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }
    }
