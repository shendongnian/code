        public void ConfigureServices(IServiceCollection services)
            { 
                services.AddMvcCore()
                        .AddJsonFormatters().AddXmlSerializerFormatters();
            }
