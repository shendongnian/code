    public static List<USBDeviceInfo> ShowUSB()
    {
        var devices = GetUSBDevices();
        foreach (var device in devices)
        {
            var deviceIDs = usbDevice.DevicePNPDeviceID.Split(new Char[] { '\\', '&', '_' });
            device.DeviceVID = deviceIDs[2];
            device.DevicePID = deviceIDs[4];
        }
        return devices;
    }
