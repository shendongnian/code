    class HttpSessionUserContext : IUserContext 
    {
        //Your specific implementation of getting the user name from your context
        public string CurrentUserName => (string)HttpContext.Session["userName"];
    }
