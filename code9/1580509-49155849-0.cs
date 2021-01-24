    using System.Linq;
    // app is of type IApplicationBuilder
    // RegisteredDBContext is the DBContext I have dependency injected
    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RegisteredDBContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    var msg = "There are pending migrations application will not start. Make sure migrations are ran.";
                    throw new InvalidProgramException(msg);
                    // Instead of error throwing, other code could happen
                }
            }
