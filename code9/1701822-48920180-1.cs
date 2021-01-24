    public static void Register(HttpConfiguration config)
    {
    	// ...
    
    	var binderProvider = new CustomModelBinderProvider<string>(new EmptyStringToNullModelBinder());
    	config.Services.Insert(typeof(ModelBinderProvider), 0, binderProvider);
    }
