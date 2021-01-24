    services.AddTransient<IMasterRepository>(serviceProvider => {
        IMasterRepository result = NullRepository.Empty;
        var _serviceFactory = new RepositoriesFactory(Configuration);
        if (Authenticated) {
            result = _serviceFactory.CreateMasterRepository();
        }
        return result;
    });
