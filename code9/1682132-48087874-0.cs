    public class UserAuthenticationManager : IUserAuthenticationManager
    {
        HttpContext _httpContext;
        public UserAuthenticationManager(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContext = httpContextAccessor?.HttpContext;
        }
        public ClaimsIdentity GetClaimsIdentity()
        {
            return (this._httpContext.User.Identity as ClaimsIdentity);
        }
    }
