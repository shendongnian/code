    string aqs = SerialDevice.GetDeviceSelector();
    var deviceCollection = await DeviceInformation.FindAllAsync(aqs);
    List<string> portNamesList = new List<string>();
    foreach (var item in deviceCollection)
    {
         var serialDevice = await SerialDevice.FromIdAsync(item.Id);
         var portName = serialDevice.PortName;
         portNamesList.Add(portName);
    }
