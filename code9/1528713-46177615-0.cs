    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddMvc();
    	services.AddOData();
    	services.AddMvcCore(options =>
    	{
    		// loop on each OData formatter to find the one without a supported media type
    		foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
    		{
    			// to comply with the media type specifications, I'm using the prs prefix, for personal usage
    			outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.dummy-odata"));
    		}
    	});
    }
