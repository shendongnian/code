    Device1[] d1 = GetDevice1Arr();
    Device2[] d2 = GetDevice2Arr();
    foreach(var device1 in d1)
    {
        device1.IsExist = d2.Any(device2 => 
                                 device2.DeviceName == device1.DeviceName 
                              && device2.DeviceIP == device1.IP));
    }
