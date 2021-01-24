    services.AddMvc()
        .AddJsonOptions(options =>
        {
            options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;
        });
