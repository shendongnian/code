                services
                .AddDbContext<BloggingContext>()
                .AddTransient<IBloggingContext, BloggingContext>()
                .AddTransient<IBloggingContextFactory, BloggingContextFactory>(
                        sp => new BloggingContextFactory( () => sp.GetService<IBloggingContext>())
                    );
