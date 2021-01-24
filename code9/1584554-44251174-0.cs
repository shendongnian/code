    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Owin;
    using Microsoft.Owin.FileSystems;
    using Microsoft.Owin.StaticFiles;
    using System.IO;
    
    namespace SealingServer
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapWhen(ctx => ctx.Request.Headers.Get("Host").Equals("subdomain1.site.com"), app2 =>
                {
                    var firstClientRoot = Path.Combine("./firstClient/");
                    var firstClientFileSystem = new PhysicalFileSystem(firstClientRoot);
    
                    var fileServerOptions = new FileServerOptions();
                    fileServerOptions.EnableDefaultFiles = true;
                    fileServerOptions.FileSystem = firstClientFileSystem;
                    fileServerOptions.DefaultFilesOptions.DefaultFileNames = new[] {"home.html"};
                    fileServerOptions.StaticFileOptions.OnPrepareResponse = staticFileResponseContext =>
                    {
                        staticFileResponseContext.OwinContext.Response.Headers.Add("Cache-Control", new[] { "public", "max-age=0" });
                    };
    
                    app2.UseFileServer(fileServerOptions);
                });
                app.MapWhen(ctx => ctx.Request.Headers.Get("Host").Equals("subdomain2.site.com"), app2 =>  
                {
                    var secondClientRoot = Path.Combine("./secondClient/");
                    var secondClientFileSystem = new PhysicalFileSystem(secondClientRoot);
    
                    var fileServerOptions = new FileServerOptions();
                    fileServerOptions.EnableDefaultFiles = true;
                    fileServerOptions.FileSystem = secondClientFileSystem;
                    fileServerOptions.DefaultFilesOptions.DefaultFileNames = new[] { "home.html" };
                    fileServerOptions.StaticFileOptions.OnPrepareResponse = staticFileResponseContext =>
                    {
                        staticFileResponseContext.OwinContext.Response.Headers.Add("Cache-Control", new[] { "public", "max-age=0" });
                    };
    
                    app2.UseFileServer(fileServerOptions);
                });
            }
        }
    }
