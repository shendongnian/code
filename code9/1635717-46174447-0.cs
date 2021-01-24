    private async Task ConnectToWatcher(DeviceInformation deviceInfo) {
    try {
        // get the device
        BluetoothLEDevice device = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
        // get the GATT service
        Thread.Sleep(150);
        var gattServicesResult = await device.GetGattServicesForUuidAsync(new Guid(RX_SERVICE_UUID));
        service = gattServicesResult.Services[0];
        // get the GATT characteristic
        Thread.Sleep(150);
        var gattCharacteristicsResult = await service.GetCharacteristicsForUuidAsync(new Guid(RX_CHAR_UUID));
        characteristic = gattCharacteristicsResult.Characteristics[0];
        // check Characteristic Configuration Descriptor
	    var currentDescriptorValue = await characteristic.ReadClientCharacteristicConfigurationDescriptorAsync();
        if (currentDescriptorValue.ClientCharacteristicConfigurationDescriptor != GattClientCharacteristicConfigurationDescriptorValue.Notify)
        {
             var status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
	    }
        // register for notifications
        Thread.Sleep(150);
        characteristic.ValueChanged += (sender, args) => {
            Debug.WriteLine($"[{device.Name}] Received notification containing {args.CharacteristicValue.Length} bytes");
        };
        enableTXNotification();
    } catch (Exception ex) when ((uint)ex.HResult == 0x800710df) {
        Debug.WriteLine("bluetooth error 1");
        // ERROR_DEVICE_NOT_AVAILABLE because the Bluetooth radio is not on.
    }
