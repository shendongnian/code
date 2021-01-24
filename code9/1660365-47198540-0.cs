            using (var serviceScope app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<YourDbContext>();
                context.Database.Migrate();
            }
