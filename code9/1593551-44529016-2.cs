    System.ArgumentException: The directory name D:\Daten7\ is invalid.
    Parameter name: path
       at System.IO.FileSystemWatcher..ctor(String path, String filter)
       at System.IO.FileSystemWatcher..ctor(String path)
       at Microsoft.Extensions.FileProviders.PhysicalFileProvider.CreateFileWatcher(String root)
       at Microsoft.Extensions.FileProviders.PhysicalFileProvider..ctor(String root)
       at WebApplication1.Startup.Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
