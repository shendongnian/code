    public class LoginController : ApiController
        {
            [HttpPost]
            [Route("api/Login/Authenticate")]
            public bool isAuthenticate(LoginVal val)
            {
                bool auth = false;
                using (HostingEnvironment.Impersonate())
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                    if (ctx.ValidateCredentials (val.UserID, val.Password))
                    {
                        auth = true;
                    }
                }
                return auth;
            }
        }
