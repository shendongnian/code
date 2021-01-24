    // This needs the following capabilities
    // <iot:Capability Name="lowLevelDevices" />
    // <DeviceCapability Name="109b86ad-f53d-4b76-aa5f-821e2ddf2141"/>
    if (LightningProvider.IsLightningEnabled)
    {
        LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
    }
    var gpioController = GpioController.GetDefault();
    // gpioController is valid
