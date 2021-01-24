    private static bool IsConnectable(DeviceInformation deviceInformation)
    {
        if (string.IsNullOrEmpty(deviceInformation.Name))
            return false;
        // Let's make it connectable by default, we have error handles in case it doesn't work
        bool isConnectable = (bool?)deviceInformation.Properties["System.Devices.Aep.Bluetooth.Le.IsConnectable"] == true;
        bool isConnected = (bool?)deviceInformation.Properties["System.Devices.Aep.IsConnected"] == true;
        return isConnectable || isConnected;
    }
