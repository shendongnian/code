        services.AddMvc( opt => {
            var readerFactory = services.BuildServiceProvider()
                .GetRequiredService<IHttpRequestStreamReaderFactory>();
            opt.ModelBinderProviders.Insert(0,
                new DefaultHybridModelBinderProvider(opt.InputFormatters, readerFactory));
        });
