    public class WebHostBuilder
    {
        private readonly IHostingEnvironment _hostingEnvironment // = new HostingEnvironment(whatToSetHere ???);
    
        public WebHostBuilder(int i)
        {
            _hostingEnvironment = new HostingEnvironment(i);
        }
    }
