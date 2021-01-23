    app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            ...
                            var lf = builder.ApplicationServices.GetService<ILoggerFactory>();
                            var logger = lf.CreateLogger("myExceptionHandlerLogger");
                            logger.LogDebug("I am a debug message");
                            ...
                        });
                });
