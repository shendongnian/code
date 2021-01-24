            services.Configure<MongoDbSettings>(options =>
            {
                ...
                options.Collections = GlobalSettingsConfiguration.GetSection("MongoDBItems:Collections").Get<Dictionary<string, string>>();      
            });
