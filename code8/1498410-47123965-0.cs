    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //...
            config.ParameterBindingRules.Insert(0, GetCustomParameterBinding);
            TypeDescriptor.AddAttributes(typeof(ObjectId), new TypeConverterAttribute(typeof(ObjectIdConverter)));
            //...
        }
    
        public static HttpParameterBinding GetCustomParameterBinding(HttpParameterDescriptor descriptor)
        {
            if (descriptor.ParameterType == typeof(ObjectId))
            {
                return new ObjectIdParameterBinding(descriptor);
            }
            // any other types, let the default parameter binding handle
            return null;
        }
    }
    
    public class ObjectIdParameterBinding : HttpParameterBinding, IValueProviderParameterBinding
    {
        public ObjectIdParameterBinding(HttpParameterDescriptor desc)
            : base(desc)
        {
        }
    
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            try
            {
                SetValue(actionContext, new ObjectId(actionContext.ControllerContext.RouteData.Values[Descriptor.ParameterName] as string));
                return Task.CompletedTask;
            }
            catch (FormatException)
            {
                throw new BadRequestException("Invalid id format");
            }
        }
    
        public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; } = new[] { new QueryStringValueProviderFactory() };
    }
    
    public class ObjectIdConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
    }
