    private static void ConnectByID_OrAddr2(UInt64 btAddr)
    {
        BluetoothLEDevice.FromBluetoothAddressAsync(btAddr)
            .ContinueWith(btLEDevTask => // Callback for when first task completes
            {
                var btLEDev = btLEDevTask.Result;
                if (btLEDev == null)
                {
                    // TODO: failure notifications...
                    return Task.FromResult<GattDeviceServicesResult>(null);
                }
                return btLEDev.GetGattServicesAsync(BluetoothCacheMode.Uncached);
            })
            .Unwrap()
            .ContinueWith(resultTask =>// Callback for when second task completes
            {
                var result = resultTask.Result;
                Console.WriteLine("Result:" + result);
            });
    }
