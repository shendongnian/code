            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new MoneyModelBinderProvider());
            }).AddJsonOptions(options =>
            {              
                options.SerializerSettings.Converters.Add(new MoneyJsonConverter());
            });
