     services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll", p =>
                    {
                        p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
                });
