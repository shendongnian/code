    public class MyBinder : IModelBinder
    {
        private readonly MvcJsonOptions jsonOptions;
        public MyBinder(IOptions<MvcJsonOptions> options)
        {
            jsonOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Your binding logic here
            ...
            return Task.CompletedTask;
        }
    }
