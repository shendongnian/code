    var devices = await   DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(new Guid("00002000-0000-1000-8000-00805f9b34fb")), null);
                for (int i = 0; i<devices.Count; i++)
                {    
                    GattDeviceService service = await GattDeviceService.FromIdAsync(devices[i].Id);
            GattCharacteristic characteristic = service.GetCharacteristics(new Guid("00002001-0000-1000-8000-00805f9b34fb")).FirstOrDefault();        
                    await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
            AddValueChangedHandler(characteristic);
    }
    private bool isValueChangedHandlerRegistered = false;//make this a field!
     private void AddValueChangedHandler(GattCharacteristic selectedCharacteristic )
            {
                if (!isValueChangedHandlerRegistered)
                {
                    selectedCharacteristic.ValueChanged += CounterCharacteristic_ValueChanged;
                    isValueChangedHandlerRegistered = true;
                }
            }
