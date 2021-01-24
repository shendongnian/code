    namespace Demo.Web.Controllers.Api.Front
    {
        [Route("api/front/[controller]/[action]/[id]")]
        public class UserAuthenticationController : ApiController
        {
            [HttpPost]
            [ActionName(ActionNameConstants.PostLogin)]
            public void Post(FrontLoginModel frontLoginModel)
            {
    
            }
        }
    }
