            public class BasicAuthenticationAttribute : ActionFilterAttribute
            {
                public string BasicRealm { get; set; }
                protected string Username { get; set; }
                protected string Password { get; set; }
         
                public BasicAuthenticationAttribute(string username, string password)
                {
                    this.Username = username;
                    this.Password = password;
                }
         
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                    var req = filterContext.HttpContext.Request;
                    var auth = req.Headers["Authorization"];
                    if (!String.IsNullOrEmpty(auth))
                    {
                        var cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                        var user = new { Name = cred[0], Pass = cred[1] };
                        if (user.Name == Username && user.Pass == Password) return;
                    }
                    filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", String.Format("Basic realm=\"{0}\"", BasicRealm ?? "Ryadel"));
                    /// thanks to eismanpat for this line: http://www.ryadel.com/en/http-basic-authentication-asp-net-mvc-using-custom-actionfilter/#comment-2507605761
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
