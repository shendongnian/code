	public class Startup
	{
		public void ConfiguresServices(IServiceCollection services)
		{
			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme /* this sets the default authentication scheme */)
				.AddJwtBearer(options =>
				{
					// Configure options here
				});
		}
		public void Configure(IApplicationBuilder app)
		{
			// This inserts the middleware that will execute the 
			// default authentication scheme handler on every request
			app.UseAuthentication();
            app.UseMvc();
		}
	}
