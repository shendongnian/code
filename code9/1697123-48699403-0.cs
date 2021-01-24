    public class UserContext
    {
        private readonly IHttpContextAccessor _accessor;
        public RequestContextAdapter(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
        public string UserID
        {
            get
            {
                // you have access to HttpRequest object here
                //this._accessor.HttpContext.Request
            }
        }
    }
