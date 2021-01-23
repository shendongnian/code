    void StartWatcher()
    {
        ResultCollection.Clear();
        string selector = BluetoothLEDevice.GetDeviceSelector();
        DeviceWatcher = DeviceInformation.CreateWatcher(selector);
        DeviceWatcher.Added += async (deviceWatcher, deviceInformation) =>
        {
            await OnUiThread(() =>
            {
                ResultCollection.Add(deviceInformation);
            });
        };
        DeviceWatcher.Start();
    }
