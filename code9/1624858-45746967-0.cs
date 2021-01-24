        public class BasicAuthAuthorizeAttribute : AuthorizeAttribute
        {
            public BasicAuthAuthorizeAttribute()
            {
                ActiveAuthenticationSchemes = "BasicAuth";
            }
        }
    And use it on your actions like you would before:
        [BasicAuthAuthorize]
        public string SomeAction()
        {
            //snip
        }
