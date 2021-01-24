    public class TestSmtpConfigOptions : IOptions<SmtpConfig> {
        private static Lazy<SmtpConfig> configuration { get; }
        static TestSmtpConfigOptions() {
            configuration = new Lazy<SmtpConfig>(GetConfiguration);
        }
        public SmtpConfig Value {
            get { return configuration.Value; }
        }
        private static SmtpConfig GetConfiguration() {
            var configuration = new SmtpConfig();
            var path = Path.Combine("config", "appsettings.development.json");
            new ConfigurationBuilder()
                .SetBasePath("path/to/base/directory/of/project")
                .AddJsonFile(path, optional: true)
                .Build()
                .GetSection(nameof(SmtpConfig))
                .Bind(configuration);
            return configuration;
        }
    }
