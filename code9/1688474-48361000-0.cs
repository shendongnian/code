    app.UseFileServer(new FileServerOptions
    {
        StaticFileOptions = new StaticFileOptions
        {
            OnPrepareResponse = (context) =>
            {
                // Disable caching of all static files.
                context.Context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                context.Context.Response.Headers["Pragma"] = "no-cache";
                context.Context.Response.Headers["Expires"] = "-1";
            }
        }
    });
