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
    }
    // the variable devices will now hold an array of all detected BT devices.
