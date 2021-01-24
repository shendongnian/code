     static GattCharacteristic charac = null;
      public static async Task connectToAddress()
      {
         Guid guid = new Guid("6e400001b5a3f393e0a9e50e24dcca9e"); // Base UUID for UART service
         Guid charachID = new Guid("6e400003b5a3f393e0a9e50e24dcca9e"); // RX characteristic UUID
         deviceReference = await BluetoothLEDevice.FromBluetoothAddressAsync(_deviceAddress);
         GattDeviceServicesResult result = await deviceReference.GetGattServicesAsync();
         //Allways check result!
         if (result.Status == GattCommunicationStatus.Success)
         {
            //Put following two lines in try/catch to or check for null!!
            var characs = await result.Services.Single(s => s.Uuid == guid).GetCharacteristicsAsync();
            //Make charac a field so you can use it in Charac_ValueChanged.
             charac = characs.Characteristics.Single(c => c.Uuid == charachID);
            GattCharacteristicProperties properties = charac.CharacteristicProperties;
            if (properties.HasFlag(GattCharacteristicProperties.Read))
            {
               Debug.Write("This characteristic supports reading from it.");
            }
            if (properties.HasFlag(GattCharacteristicProperties.Write))
            {
               Debug.Write("This characteristic supports writing.");
            }
            if (properties.HasFlag(GattCharacteristicProperties.Notify))
            {
               Debug.Write("This characteristic supports subscribing to notifications.");
            }
            try
            {
               //Write the CCCD in order for server to send notifications.               
               var notifyResult = await charac.WriteClientCharacteristicConfigurationDescriptorAsync(
                                                         GattClientCharacteristicConfigurationDescriptorValue.Notify);
               if (notifyResult == GattCommunicationStatus.Success)
               {
                  Debug.Write("Successfully registered for notifications");
               }
               else
               {
                  Debug.Write($"Error registering for notifications: {notifyResult}");
               }
            }
            catch (UnauthorizedAccessException ex)
            {
               Debug.Write(ex.Message);
            }
            charac.ValueChanged += Charac_ValueChangedAsync; ;
         }
         else
         {
            Debug.Write("No services found");
         }
      }
      private static async void Charac_ValueChangedAsync(GattCharacteristic sender, GattValueChangedEventArgs args)
      {
         CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out byte[] data);
         string dataFromNotify;
         try
         {
            //Asuming Encoding is in ASCII, can be UTF8 or other!
            dataFromNotify = Encoding.ASCII.GetString(data);
            Debug.Write(dataFromNotify);
         }
         catch (ArgumentException)
         {
            Debug.Write("Unknown format");
         }
         GattReadResult dataFromRead = await charac.ReadValueAsync();
         Debug.WriteLine("DATA FROM NOTIFY: " + data.ToString());
         CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out byte[] dataRead);
         string dataFromReadResult;
         try
         {
            //Asuming Encoding is in ASCII, can be UTF8 or other!
            dataFromReadResult = Encoding.ASCII.GetString(dataRead);
            Debug.Write("DATA FROM rEADY: " + dataFromReadResult);
         }
         catch (ArgumentException)
         {
            Debug.Write("Unknown format");
         }
      }
