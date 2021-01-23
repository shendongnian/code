    public class ConfigureIntegrationSettings : IConfigureOptions<Integration>
        {
            public void Configure(Integration options)
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("FOO")))
                    options.FOO_API = Environment.GetEnvironmentVariable("FOO_API");
      
            }
        }
