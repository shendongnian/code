    public class MockHostingEnvironment : IHostingEnvironment, ISingletonDependency
    {
        public string EnvironmentName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string WebRootPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "wwwroot");
        public IFileProvider WebRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string ContentRootPath { get; set; } = Environment.CurrentDirectory;
        public IFileProvider ContentRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
