    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddJsonFullFormatters(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            ServiceDescriptor descriptor = ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, YourMvcOptionsSetup>();
            builder.Services.TryAddEnumerable(descriptor);
            return builder;
        }
    }
