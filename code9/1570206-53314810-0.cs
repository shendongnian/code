public void ConfigureServices(IServiceCollection services)
{
	services.AddMvc()
	    .AddApplicationPart(typeof(ServiceHookController).Assembly);
}
