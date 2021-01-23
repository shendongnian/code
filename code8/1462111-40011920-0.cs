    SerialDevice serialPort = null;
    private async void SerialDeviceOperation()
    {
        var selector = SerialDevice.GetDeviceSelector();
        var device = await DeviceInformation.FindAllAsync(selector);
        try
        {
            while (serialPort == null)
            {
                serialPort = await SerialDevice.FromIdAsync(device[0].Id);
            }
            // Your code in here
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        // Do something...
        // Write or read data via serial device
        // ...
        // After complete the operation, dispose the device
        serialPort.Dispose();
    }
