            app.Use((context, func) =>
            {
                if (context.Request.Path.StartsWithSegments(new PathString("/data/v1/$metadata"), StringComparison.OrdinalIgnoreCase))
                {
                    var model = app.ApplicationServices.GetService<IEdmModel>();
                    MemoryStream stream = new MemoryStream();
                    InMemoryMessage message = new InMemoryMessage() {Stream = stream};
                    ODataMessageWriterSettings settings = new ODataMessageWriterSettings();
                    ODataMessageWriter writer = new ODataMessageWriter((IODataResponseMessage)message, settings, model);
                    writer.WriteMetadataDocument();
                    string output = Encoding.UTF8.GetString(stream.ToArray());
                    return context.Response.WriteAsync(output);
                }
                return func();
            });
 
