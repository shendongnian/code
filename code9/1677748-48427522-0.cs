	public void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<IApiInfoService, ApiInfoService>();
		services.AddTransient<IApiVersion, ApiVersion>();
		services.AddTransient<IContentService, ContentService>();
		services.AddTransient<IIdGenerator, GuidIdGenerator>();
		// Add framework services.
		services.AddMvc(
			mvcConfig => {
				mvcConfig.InputFormatters.OfType<JsonInputFormatter>().First().SupportedMediaTypes.Add(
					MediaTypeHeaderValue.Parse(ContentTypes.VENDOR_MIME_TYPE)
				);
			}
		);
	}
