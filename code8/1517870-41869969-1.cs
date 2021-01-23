        public async void InitializeServiceAsync(string deviceId)
        {
            try
            {
                _service = await GattDeviceService.FromIdAsync(deviceId);
                System.Diagnostics.Debug.WriteLine(_service.Device.Name);
                if (_service == null)
                    return;
                var service = _service.Device.GattServices;
                foreach (var item in service)
                {
                    var chars = item.GetAllCharacteristics();
                    foreach (var cha in chars)
                    {
                        _service = item;
                        Subscribe(item.AttributeHandle, cha.AttributeHandle);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR: Accessing your device failed." + Environment.NewLine + e.Message);
            }
        }
        public async void Subscribe(ushort serviceHandle, ushort characteristicHandle)
        {
            try
            {
                var service = _service.Device.GattServices.Single(x => x.AttributeHandle == serviceHandle);
                var characteristic = service.GetAllCharacteristics().Single(x => x.AttributeHandle == characteristicHandle);
                if (characteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    System.Diagnostics.Debug.WriteLine("serviceHandle=" + serviceHandle);
                    System.Diagnostics.Debug.WriteLine("characteristicHandle=" + characteristicHandle);
                    await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                    System.Diagnostics.Debug.WriteLine("register value changed event");
                    characteristic.ValueChanged += Oncharacteristic_ValueChanged;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
