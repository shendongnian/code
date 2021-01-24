    int maxDevices = 10;
    List<Device> devices = new List<Device>();
    BluetoothClient bc = new BluetoothClient();
    BluetoothDeviceInfo[] array = bc.DiscoverDevices(maxDevices);
    int count = array.Length;
    for (int i = 0; i < count; i++)
    {
        Device device = new Device(array[i]);
        devices.Add(device);
        // the variable device will now hold a detected BT device.
        // Now you can connect to the device:
        bc.Connect(new BluetoothEndPoint((BluetoothAddress)adres,service));
           
        // Send a message to the device
        System.Net.Sockets.NetworkStream stream = bc.GetStream();
        StreamWriter streamWriter = new StreamWriter(stream);
        streamWriter.WriteLine("! 0 200 200 210 1");
    }
    // the variable devices will now hold an array of all detected BT devices.
