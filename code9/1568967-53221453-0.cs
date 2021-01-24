    var assembly = typeof(Program).GetTypeInfo().Assembly;
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<ApplicationUser, ApplicationUserView> ().IgnoreAllPropertiesWithAnInaccessibleSetter();}, assembly);
