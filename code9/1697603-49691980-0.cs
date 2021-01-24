    _device = HidDevices.Enumerate(VendorId, ProductId).FirstOrDefault();
    while (_device.IsConnected)
    {
        if (_device == null)
        {
            Console.WriteLine("No device was found");
            return;
        }
        _device.OpenDevice();
        _device.Inserted += DeviceAttachedHandler;
        _device.Removed += DeviceRemovedHandler;
        _device.MonitorDeviceEvents = true;
        var message = new byte[] { 0, 81, 80, 73, 71, 83, 183, 169, 13 };
        // Adding a timeout here would prevent hanging issue
        _device.Write(message, 500);
         _device.ReadReport(OnReport);
        //Console.WriteLine("Reader found, press any key to exit.");
        //Console.ReadKey();
        //_device.CloseDevice();
    }
