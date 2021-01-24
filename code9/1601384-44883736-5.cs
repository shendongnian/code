    public class YourMvcOptionsSetup : IConfigureOptions<MvcOptions>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly ArrayPool<char> _charPool;
        private readonly ObjectPoolProvider _objectPoolProvider;
        public YourMvcOptionsSetup(ILoggerFactory loggerFactory, IOptions<MvcJsonOptions> jsonOptions, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
        {
            //Validate parameters and set fields
        }
        public void Configure(MvcOptions options)
        {
            var jsonFullInputFormatter = new JsonFullInputFormatter(
                _loggerFactory.CreateLogger<JsonFullInputFormatter>(),
                _jsonSerializerSettings,
                _charPool,
                _objectPoolProvider
            );
            options.InputFormatters.Add(jsonFullInputFormatter);
            options.OutputFormatters.Add(new JsonFullOutputFormatter(
                _jsonSerializerSettings,
                _charPool
            ));
        }
      
