    settings = new SpiConnectionSettings(0); //chip select line 0
    settings.ClockFrequency = 1000000;
    settings.Mode = SpiMode.Mode0;
    String spiDeviceSelector = SpiDevice.GetDeviceSelector();
    devices = await DeviceInformation.FindAllAsync(spiDeviceSelector);
    _spi1 = await SpiDevice.FromIdAsync(devices[0].Id, settings);
