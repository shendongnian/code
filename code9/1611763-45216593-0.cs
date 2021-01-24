        protected void Application_BeginRequest() { CurrentContext = new YourDbcontext; }
        protected void Application_EndRequest()
        {
            if (CurrentContext != null)
                CurrentContext .Dispose();
        }
