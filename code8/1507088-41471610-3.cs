    public class OwinAuthenticationService : IAuthenticationService
    {
        private readonly HttpContextBase _context;
        private const string AuthenticationType = "ApplicationCookie";
    
        public OwinAuthenticationService(HttpContextBase context)
        {
            _context = context;
        }
    
        public void SignIn(User user)
        {
            IList<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                };
    
            ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);
    
            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;
    
            authenticationManager.SignIn(identity);
        }
    
        public void SignOut()
        {
            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;
    
            authenticationManager.SignOut(AuthenticationType);
        }
    }
