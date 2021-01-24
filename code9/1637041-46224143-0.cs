    	public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
					.CreateScope())
			{
				AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();
				if (!context.Products.Any())
				{
					// Seed Here
				}
				context.SaveChanges();
			}
		}
    
