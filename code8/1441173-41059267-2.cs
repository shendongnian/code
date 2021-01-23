    services.AddMvc().AddMvcOptions(options =>
    {
        // replace ComplexTypeModelBinderProvider with its descendent - IoCModelBinderProvider
        var provider = options.ModelBinderProviders.FirstOrDefault(x => x.GetType() == typeof(ComplexTypeModelBinderProvider));
        var binderIndex = options.ModelBinderProviders.IndexOf(provider);
        options.ModelBinderProviders.Remove(provider);
        options.ModelBinderProviders.Insert(binderIndex, new DiModelBinderProvider());
    });
