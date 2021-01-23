    public static IMvcBuilder AddMvc(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        var builder = services.AddMvcCore();
        builder.AddApiExplorer();
        builder.AddAuthorization();
        AddDefaultFrameworkParts(builder.PartManager);
        // Order added affects options setup order
        // Default framework order
        builder.AddFormatterMappings();
        builder.AddViews();
        builder.AddRazorViewEngine();
        builder.AddCacheTagHelper();
        // +1 order
        builder.AddDataAnnotations(); // +1 order
        // +10 order
        builder.AddJsonFormatters();
        builder.AddCors();
        return new MvcBuilder(builder.Services, builder.PartManager);
    }
