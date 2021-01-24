    public static class AuthenticateClientExtension
    {
    	public static IApplicationBuilder UseClientAuthentication(this IApplicationBuilder builder)
    	{
    		var scope = builder.ApplicationServices.CreateScope();
    		ApiDbContext db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    
    		return builder.UseMiddleware<AuthenticateClient>(db);
    	}
    }
