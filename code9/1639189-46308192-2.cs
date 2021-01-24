    new StaticFileOptions()
    {
        OnPrepareResponse = context =>
        {
            context.Context.Response.Headers["Content-Disposition"] = "attachment";
        }
    }
