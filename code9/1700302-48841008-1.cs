	public void ConfigureServices(IServiceCollection services)
    {
	    services
			.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
			.AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("MyScheme", options => { /* configure options */ })
	}
