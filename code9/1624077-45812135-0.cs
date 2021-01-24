    public class Startup
	{
		public void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<MiddlewareInjectorOptions>();
		}
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseDeveloperExceptionPage();
			var injectorOptions = app.ApplicationServices.GetService<MiddlewareInjectorOptions>();
			app.UseMiddlewareInjector(injectorOptions);
			app.UseWelcomePage();
		}
	}
