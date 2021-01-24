                services.AddDbContext<FooContext>(options =>
                    options.UseSqlServer(BarConnectionString,
                        sqlServerOptions => sqlServerOptions.CommandTimeout(300)).UseLazyLoadingProxies()
                                      .ConfigureWarnings(warnings =>
                                      warnings.Throw(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.QueryClientEvaluationWarning))
                        );
