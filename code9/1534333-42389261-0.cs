    public void Configuration(IAppBuilder application)
    {
       //Other middlewares and configurations
        ....
       application.UseFileServer(new FileServerOptions()
       {
           RequestPath = new PathString("/myPath1/public"),
           FileSystem = new PhysicalFileSystem(m_FolderPathProvider.myPath1FolderPublic)
       });
    
       application.UseFileServer(new FileServerOptions()
       {
           RequestPath = new PathString("/myPath2/public"),
           FileSystem = new PhysicalFileSystem(m_FolderPathProvider.myPath2FolderPublic)
       });
    
           // Attribute routing.
                .....
     }
