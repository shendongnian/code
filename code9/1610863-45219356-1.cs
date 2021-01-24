    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var physicalFileSystem = new PhysicalFileSystem(@"./dist");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[]
            {
                "index.html"
            };
    
            app.UseFileServer(options);
        }
    }
