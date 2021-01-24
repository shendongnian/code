    public static int EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder,
     bool autoMigrateDatabase)
    {
	    // seed the database using an extension method
    	using (var serviceScope = applicationBuilder.ApplicationServices
       .GetRequiredService<IServiceScopeFactory>().CreateScope())
       {
		   var context = serviceScope.ServiceProvider.GetService<DwContext>();
		   if (autoMigrateDatabase)
		   {
			   context.Database.Migrate();
		   }
		   return context.EnsureSeedData();
	   }
    }
