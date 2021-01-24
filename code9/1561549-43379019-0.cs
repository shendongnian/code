     private async Task<SettingsReturn> writeSettingTransition(BluetoothLEDevice device, byte[] byteSettings)
            {
                bool success = false;
                //Check if device is available
                if (device != null)
                {
                    Guid SERVICE_CUSTOM = new Guid("7e0bc6be-8271-4f5a-a126-c24220e6250c");
                    GattDeviceService service = device.GetGattService(SERVICE_CUSTOM);
                    //Check if service is available
                    if (service == null)
                    {
                        return SettingsReturn.INIT_ERROR;
                    }
                    GattCharacteristic characteristic = service.GetCharacteristics(BLETestApp.CHAR_SETTINGS)[0];
                    //Check if characteristic is available
                    if (characteristic == null)
                    {
                        return SettingsReturn.INIT_ERROR;
                    }
    
                    IBuffer writeBuffer = byteSettings.AsBuffer();// using Windows.Storage.Streams
    
                    try
                    {
                        // BT_Code: Writes the value from the buffer to the characteristic.
                        var result = await characteristic.WriteValueAsync(writeBuffer);
                        if (result == GattCommunicationStatus.Success)
                        {
                            // NotifyUser("Successfully wrote value to device" );
                            success = true;
                        }
                        else
                        {
                            // NotifyUser($"Write failed: {result}");
                            success = false;
                        }
                    }
                    catch (Exception ex) when ((uint)ex.HResult == 0x80650003 || (uint)ex.HResult == 0x80070005)
                    {
                        // E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED or E_ACCESSDENIED
                        // This usually happens when a device reports that it support writing, but it actually doesn't.
                        // NotifyUser(ex.Message, NotifyType.ErrorMessage);
                    }
    
                    if (success)
                    {
                        // Take care of the 8 bit byte for the counter (max = 255 (unsigned))
                        if (TRANSACTION_ID > 250)
                        {
                            TRANSACTION_ID = 0;
                        }
                        else
                        {
                            // Count TANSACTION_ID one up
                            TRANSACTION_ID++;
                        }
                        return SettingsReturn.OK;
                    }
                    else
                    {
                        return SettingsReturn.WRITE_ERROR;
                    }
                }
                else
                {
                    return SettingsReturn.INIT_ERROR;
                }
            }
