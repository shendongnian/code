    services.AddMvc()
        .AddDataAnnotationsLocalization(options =>
        {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                return new DataAnnotationStringLocalizer(
                    factory?.Create(typeof(type)),
                    factory?.Create(typeof(SharedResource))
                );
            }
        });
