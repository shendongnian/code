    services.AddMvc()
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                return new DataAnnotationStringLocalizer(
                    factory?.Create(type),
                    factory?.Create(typeof(SharedResource))
                );
            }
        });
