    // instead of passing an option configuration delegate here…
    services.AddAuthentication().AddJwtBearer();
    // … we register a IConfigureOptions<JwtBearerOptions> instead
    services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
    // … ConfigureJwtBearerOptions could look like this:
    class ConfigureJwtBearerOptions : IConfigureOptions<JwtBearerOptions>
    {
        private readonly ApplicationSettings _settings;
        public ConfigureJwtBearerOptions(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }
        public void Configure(JwtBearerOptions options)
        {
            // configure JwtBearerOptions here, and use your ApplicationSettings
            options.MetadataAddress = _settings.JwtMetadataAddress;
        }
    }
