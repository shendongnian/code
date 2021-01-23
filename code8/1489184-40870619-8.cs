    public class AppRootPathProvider : IRootPathProvider
    {
        private readonly IHostingEnvironment _environment;
    
        public AppRootPathProvider(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public string GetRootPath()
        {
            return _environment.WebRootPath;
        }
    }
