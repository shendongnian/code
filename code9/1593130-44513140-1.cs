    public class RegUser
    {
      public string username {get;set;}
      public string password {get;set;}
    }
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("regUser")]
        public string newUser(RegUser user)
        {
            return user.username + "_" + user.password;
        }
    }
