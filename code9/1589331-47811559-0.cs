        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
        }
