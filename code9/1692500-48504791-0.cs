    var profiles =
        Assembly
             .GetExecutingAssembly()
             .GetTypes()
             .Where(t => typeof(Profile).IsAssignableFrom(t))
             .ToList();
    Mapper.Initialize(
        mp =>
            {
                var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
                var mapper = mapperConfiguration.CreateMapper();
                container.Register(() => mapper, Lifestyle.Scoped);
            });
