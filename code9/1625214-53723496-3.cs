            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            })
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
