    string _serialSelector = SerialDevice.GetDeviceSelector();
    var infos = await DeviceInformation.FindAllAsync(_serialSelector);
    foreach (var info in infos)
    {
        var serialDevice = await SerialDevice.FromIdAsync(info.Id);
        if (serialDevice != null)
        {
            var port = serialDevice.PortName;
            Debug.WriteLine(port.ToString());
        }
    }
