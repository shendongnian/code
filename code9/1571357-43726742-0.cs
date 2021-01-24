    private IHostingEnvironment _hostingEnvironment;
        private string projectRootFolder;
        public Program(IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            projectRootFolder = env.ContentRootPath.Substring(0,
                env.ContentRootPath.LastIndexOf(@"\ProjectRoot\", StringComparison.Ordinal) + @"\ProjectRoot\".Length);
        }
