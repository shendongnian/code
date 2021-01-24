    var myDevices = await DeviceInformation.FindAllAsync(aqs);
    UsbDevice usbDevice = await Windows.Devices.Usb.UsbDevice.FromIdAsync(myDevices[0].Id);
    
    // or try init MediaCaptureInitializationSettings
    var settings = new MediaCaptureInitializationSettings()
    {
        VideoDeviceId = myDevices.FirstOrDefault()?.Id,
        PhotoCaptureSource = PhotoCaptureSource.Auto,
        StreamingCaptureMode = StreamingCaptureMode.Video,
    };
