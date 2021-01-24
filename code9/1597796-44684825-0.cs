    public class UserContextService : IUserContextServices {
        private readonly IHttpContextAccessor contextAccessor;
        private UserContext _userContext;
        public UserContextService(IHttpContextAccessor accessor) {
            contextAccessor = accessor;
        }
        private HttpContext Context {
            get {
                return contextAccessor.HttpContext;
            }
        }
        public UserContext GetUserContext() {
            if (_userContext == null && IsUserAuthenticated()) {
                var claims = Context?.User?.Claims;
                _userContext = new UserContext() {
                    Email = claims.First(p => p.Type == "email").Value,
                    AspNetUserID = claims.First(p => p.Type == "sub").Value
                };
            }
            return _userContext;
        }
        public bool IsUserAuthenticated() {
            return Context?.User?.Identity?.IsAuthenticated;
        }
    }
