	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		// Get HttpClientFactory and Configure Flurl to use it.
		var factory = (IMyCustomHttpClientFactory)app.ApplicationServices.GetService(typeof(IMyCustomHttpClientFactory));
		FlurlHttp.Configure((settings) => settings.HttpClientFactory = factory);
	}
