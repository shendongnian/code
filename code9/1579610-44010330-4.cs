    namespace Demo.Web.Controllers.Api.Admin
    {
        [Route("api/admin")]
        public class UserAuthenticationController : ApiController
        {
    
            [HttpPost,Route("login")]
            public IHttpActionResult PostAdminLogin([FromBody]AdminLoginModel adminLoginModel)
            {            
                return Ok(true);
            }
        }
    }
