    public  Stream CreateSerialPortStream(string serialPortName)
    {
        var selector = SerialDevice.GetDeviceSelector(serialPortName); //Get the serial port on port '3'
        var devicesTask = await DeviceInformation.FindAllAsync(selector);
        devicesTask.Wait();
        var devices = devicesTask.Result;
        if (devices.Any()) //if the device is found
        {
                var deviceInfo = devices.First();
                var serialDeviceTask = SerialDevice.FromIdAsync(deviceInfo.Id);
                serialDeviceTask.Wait();
                var serialDevice = serialDeviceTask.Result;        
                //Set up serial device according to device specifications:
                //This might differ from device to device
                serialDevice.BaudRate = 19600;
                serialDevice.DataBits = 8;
                serialDevice.Parity = SerialParity.None;
          }
    }
