    var aqs = SerialDevice.GetDeviceSelector();
    var dis = await DeviceInformation.FindAllAsync(aqs);
    var port = await SerialDevice.FromIdAsync(dis[0].Id);
    Debug.WriteLine("COM=" + port?.PortName);
    var aqs2 = SerialDevice.GetDeviceSelector();
    var dis2 = await DeviceInformation.FindAllAsync(aqs);
    var port2 = await SerialDevice.FromIdAsync(dis[0].Id);
    Debug.WriteLine("COM="+port2?.PortName);
