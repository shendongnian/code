    public static class AuthenticateClientExtension
    {
    	public static IApplicationBuilder UseClientAuthentication(this IApplicationBuilder builder)
    	{
    		ApiDbContext db = null;
    
    		using(var scope = builder.ApplicationServices.CreateScope())
    		{
    			db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    		}
    
    		return builder.UseMiddleware<AuthenticateClient>(db);
    	}
    }
