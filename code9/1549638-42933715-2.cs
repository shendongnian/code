csharp
public void ConfigureServices(IServiceCollection services)
{
	services.Configure<SecurityHeaderOptions>(Configuration.GetSection("SecurityHeaderOptions"));            
	services.AddScoped<SecurityHeadersBuilder>(provider =>
	{
		var option = provider.GetService<IOptions<SecurityHeaderOptions>>();
		return new SecurityHeadersBuilder(option)
		    .AddDefaultPolicy();
	});
}
