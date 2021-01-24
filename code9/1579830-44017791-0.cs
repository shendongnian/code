    public class AspNetUserContextAdapter : IUserContext
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUpService _upService;
        
        public AspNetUserContextAdapter(IHttpContextAccessor accessor, IUpService _upService) { 
            _accessor = accessor;
            _upService = upService;
        }
        public User CurrentUser
        {
            get
            {
                var context = _accessor.HttpContext;
                var tokenCookie = context.Request.Headers.FirstOrDefault(c => c.Key == "token");
                return !string.IsNullOrEmpty(tokenCookie.Value) && tokenCookie.Value != "undefined"
                    ? _upService.GetUserById(new Guid(tokenCookie.Value))
                    :  null;
            }
        }
    }
