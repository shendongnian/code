    public async Task ReInitSpi()
    {
        _spi.Dispose(); //Here is important.
        try
        {
            if (settings.ChipSelectLine == 0)
            {
                settings = new SpiConnectionSettings(1); //CS1
            }
            else
            {
                settings = new SpiConnectionSettings(SPI_CHIP_SELECT_LINE); //CS0
            }
            
            settings.ClockFrequency = 1000000;
            settings.Mode = SpiMode.Mode0;
            String spiDeviceSelector = SpiDevice.GetDeviceSelector();
            IReadOnlyList<DeviceInformation> devices = await DeviceInformation.FindAllAsync(spiDeviceSelector);
            _spi = await SpiDevice.FromIdAsync(devices[0].Id, settings);
        }
        /* If initialization fails, display the exception and stop running */
        catch (Exception ex)
        {
            throw new Exception("SPI Initialization Failed", ex);
        }
    }
