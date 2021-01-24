    class MyModuleChain : IHttpModule
    {
        private IHttpModule _module1 = new Module1();
        private IHttpModule _module2 = new Module2();
        public void Init(HttpApplication application)
        {  
            application.BeginRequest += new EventHandler(Application_BeginRequest);
            application.EndRequest += new EventHandler(Application_EndRequest);
        }
        public void Application_BeginRequest(object source, EventArgs e)
        {
            //Call the modules in a fixed order
            _module1.Application_BeginRequest(source, e);
            _module2.Application_BeginRequest(source, e);
        }
        public void Application_EndRequest(object source, EventArgs e)
        {
            //Call the modules in a fixed order
            _module1.Application_EndRequest(source, e);
            _module2.Application_EndRequest(source, e);
        }
        public void Dispose()
        {
            _module1.Dispose();
            _module2.Dispose();
        }
    }
