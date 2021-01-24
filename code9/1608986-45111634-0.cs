    interface IDatabaseAuthenticationContext
    {
        string DatabaseUserName { get; set; }
        string DatabasePassword { get; set ; }
    }
    class AuthenticationContext: IDatabaseAuthenticationContext
    {
        private readonly HttpContextBase _httpContext;
        public AuthenticationContext(HttpContextbase httpContext)
        {
            _httpContext = httpContext;
        }
        public string DatabaseUserName
        {
            get
            {
                return _httpContext.Session["DatabaseUserName"];
            }
            set
            {
                _httpContext.Session["DatabaseUserName"] = value;
            }
        }
        public string DatabasePassword
        {
            get
            {
                return _httpContext.Session["DatabasePassword"];
            }
            set
            {
                _httpContext.Session["DatabasePassword"] = value;
            }
        }
    }
