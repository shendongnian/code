        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
            services.AddMvc(options =>
            {
                var F = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var L = F.Create("ModelBindingMessages", null);
                options.ModelBindingMessageProvider.ValueIsInvalidAccessor =
                    (x) => L["The value '{0}' is invalid."];
                options.ModelBindingMessageProvider.ValueMustBeANumberAccessor =
                    (x) => L["The field {0} must be a number."];
                options.ModelBindingMessageProvider.MissingBindRequiredValueAccessor =
                    (x) => L["A value for the '{0}' property was not provided.", x];
                options.ModelBindingMessageProvider.AttemptedValueIsInvalidAccessor =
                    (x, y) => L["The value '{0}' is not valid for {1}.", x, y];
                options.ModelBindingMessageProvider.MissingKeyOrValueAccessor =
                    () => L["A value is required."];
                options.ModelBindingMessageProvider.UnknownValueIsInvalidAccessor =
                    (x) => L["The supplied value is invalid for {0}.", x];
                options.ModelBindingMessageProvider.ValueMustNotBeNullAccessor =
                    (x) => L["Null value is invalid.", x];
            })
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]{new CultureInfo("en"), new CultureInfo("fa")};
                options.DefaultRequestCulture = new RequestCulture("en", "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
