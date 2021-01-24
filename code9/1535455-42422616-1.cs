        protected void Application_BeginRequest() { CurrentContext = new YourDbContext(); }
        protected void Application_EndRequest()
        {
            if (CurrentContext != null)
                CurrentContext.Dispose();
        }
