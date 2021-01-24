     var serviceProvider = services.BuildServiceProvider();
        services.AddScoped<IDeviceService>(r => new DeviceService(
            serviceProvider.GetService<IDeviceRepository>(),
            serviceProvider.GetService<IMasterDataRepository>(),
            ));
    
        services.AddScoped<IHardwareDataService>(r => new HardwareDataService(
            serviceProvider.GetService<IDeviceService>(),
            serviceProvider.GetService<IHardwareDataRepository>()
            ));
