    [Route("api/admin/[controller]/[action]/[id]")]
    namespace Demo.Web.Controllers.Api.Admin
    {
        public class UserAuthenticationController : ApiController
        {
    
            [HttpPost, ActionName(ActionNameConstants.PostAdminLogin)]
            public IHttpActionResult PostAdminLogin(AdminLoginModel adminLoginModel)
            {            
                return Ok(true);
            }
        }
    }
