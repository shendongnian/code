    public void Configuration(IAppBuilder application)
        {
            //Other webApi configuration
                application.UseFileServer(new FileServerOptions()
                {
                    RequestPath = new PathString("/html/public"),
                    FileSystem = new PhysicalFileSystem(@"../../../MyProject/html/public"),
                });
