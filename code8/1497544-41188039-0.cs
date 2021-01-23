    var serviceInfoCollection = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort), new string[] { "System.Devices.AepService.AepId" });
    
    foreach (var serviceInfo in serviceInfoCollection)
    {
        var deviceInfo = await DeviceInformation.CreateFromIdAsync((string)serviceInfo.Properties["System.Devices.AepService.AepId"]);
    
        System.Diagnostics.Debug.WriteLine($"Device name is: '{deviceInfo.Name}' and Id is: '{deviceInfo.Id}'");
    }
