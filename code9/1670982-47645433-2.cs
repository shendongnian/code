      services.AddMvc(options =>
      {
        var workerProvider = options.ModelBinderProviders.First(p => p.GetType() == typeof(ComplexTypeModelBinderProvider));
        options.ModelBinderProviders.Insert(options.ModelBinderProviders.IndexOf(workerProvider), new FooModelBinderProvider(workerProvider));
      })
