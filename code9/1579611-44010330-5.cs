    namespace Demo.Web.Controllers.Api.Front
    {
        [Route("api/front")]
        public class UserAuthenticationController : ApiController
        {
            [HttpPost]
            [Route("login")]
            public void Post([FromBody]FrontLoginModel frontLoginModel)
            {
    
            }
        }
    }
