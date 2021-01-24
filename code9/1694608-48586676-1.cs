    services.AddTransient<IMasterRepository>(serviceProvider => {
        IMasterRepository result = null;
        var _serviceFactory = new RepositoriesFactory(Configuration);
        if (Authenticated) {
            result = _serviceFactory.CreateMasterRepository();
        }
        return result;
    });
