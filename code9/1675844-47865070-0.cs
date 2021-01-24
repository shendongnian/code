        app.Use(async (context, next) => {
                  await next();
                  if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value)){
                      context.Request.Path = "/index.html";
                      await next();
                  }
        })
        .UseDefaultFiles(new DefaultFilesOptions { DefaultFilesName = new List<string>{ "index.html" } })
        .UseStaticFiles(new StaticFilesOptions 
                        {
                           FileProvider = new PhysicalFileProvider(
                               Path.Combine(Directory.GetCurrentDiretory(), "@wwwroot")),
                               RequestPath = new PathString("")
        })
        .UseMvc();
