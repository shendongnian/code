    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            JsonConvert.DefaultSettings = () =>
            {
                return new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    Formatting = Formatting.Indented
                };
            };
            builder.Services.AddLogging();
            builder.AddExtension<BindingExtensionProvider>();
        }
    }
