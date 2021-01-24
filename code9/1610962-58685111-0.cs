    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class FromBodyAttribute : Attribute
    {
    }
    public class FromBodyBinding : IBinding
    {
        private readonly ILogger logger;
        public FromBodyBinding(ILogger logger)
        {
            this.logger = logger;
        }
        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            // Get the HTTP request
            var request = context.BindingData["req"] as DefaultHttpRequest;
            return Task.FromResult<IValueProvider>(new FromBodyValueProvider(request, logger));
        }
        public bool FromAttribute => true;
        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return null;
        }
        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }
    public class FromBodyBindingProvider : IBindingProvider
    {
        private readonly ILogger logger;
        public FromBodyBindingProvider(ILogger logger)
        {
            this.logger = logger;
        }
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new FromBodyBinding(this.logger);
            return Task.FromResult(binding);
        }
    }
    public class FromBodyValueProvider : IValueProvider
    {
        private HttpRequest request;
        private ILogger logger;
        public FromBodyValueProvider(HttpRequest request, ILogger logger)
        {
            this.request = request;
            this.logger = logger;
        }
        public async Task<object> GetValueAsync()
        {
            try
            {
                string requestBody = await new StreamReader(this.request.Body).ReadToEndAsync();
                object result = JsonConvert.DeserializeObject(requestBody);
                return result;
            }
            catch (System.Exception ex)
            {
                this.logger.LogCritical(ex, "Error deserializing object from body");
                throw ex;
            }
        }
        public Type Type => typeof(object);
        public string ToInvokeString() => string.Empty;
    }
    public class BindingExtensionProvider : IExtensionConfigProvider
    {
        private readonly ILogger logger;
        public BindingExtensionProvider(ILogger<Startup> logger)
        {
            this.logger = logger;
        }
        public void Initialize(ExtensionConfigContext context)
        {
            // Creates a rule that links the attribute to the binding
            context.AddBindingRule<FromBodyAttribute>().Bind(new FromBodyBindingProvider(this.logger));
        }
    }
