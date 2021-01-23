    public async Task InitIO()
    {
        ...
        ...
    
        try
        {
            settings = new SpiConnectionSettings(SPI_CHIP_SELECT_LINE);
            settings.ClockFrequency = 1000000;
            settings.Mode = SpiMode.Mode0;
    
            String spiDeviceSelector = SpiDevice.GetDeviceSelector();
            IReadOnlyList<DeviceInformation> devices = await DeviceInformation.FindAllAsync(spiDeviceSelector);
    
            _spi = await SpiDevice.FromIdAsync(devices[0].Id, settings);
    
        }
        catch (Exception ex)
        {
            throw new Exception("SPI Initialization Failed", ex);
        }
    
        ...
        ...
    }
