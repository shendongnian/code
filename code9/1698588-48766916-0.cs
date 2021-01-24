       public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
					.AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; });
            services.AddAutoMapper();
            services.RegisterServices();
		}
