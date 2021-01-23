    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500; // or another Status
            context.Response.ContentType = "application/json";
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                var ex = error.Error;
                await context.Response.WriteAsync(new ErrorDto()
                {
                    Code = 1, //<your custom code based on Exception Type>,
                    Message = ex.Message // or your custom message
                    // … other custom data
                }.ToString(), Encoding.UTF8);
            }
        });
    });
