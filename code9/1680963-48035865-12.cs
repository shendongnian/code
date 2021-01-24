    services.AddMvc()
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                return new DataAnnotationStringLocalizer(
                    factory?.Create(typeof(SharedResource)),
                    factory?.Create(typeof(type))
                );
            }
        });
