    public class AspNetWorkingEnvironment : IWorkingEnvironment
    {
        private readonly IHostingEnvironment _hostingEnvironment;
    
        public AspNetWorkingEnvironment(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    
        public string EnvironmentName => _hostingEnvironment.EnvironmentName;
    }
