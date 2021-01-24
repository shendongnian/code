    services.AddMvc()
      .AddMvcOptions(options =>
      {
         IHttpRequestStreamReaderFactory readerFactory = services.BuildServiceProvider().GetRequiredService<IHttpRequestStreamReaderFactory>();
         options.ModelBinderProviders.Insert(0, new TestModelBinderProvider(options.InputFormatters, readerFactory));
      });
