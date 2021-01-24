    private async void ResultCharacteristic_ReadRequestedAsync(GattLocalCharacteristic sender, GattReadRequestedEventArgs args)
    {
        // BT_Code: Process a read request. 
        using (args.GetDeferral())
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunTaskAsync(async () =>
            {
                // Get the request information.  This requires device access before an app can access the device's request. 
                GattReadRequest request = await args.GetRequestAsync();
                if (request == null)
                {
                    // No access allowed to the device.  Application should indicate this to the user.
                    rootPage.NotifyUser("Access to device not allowed", NotifyType.ErrorMessage);
                    return;
                }
    
                var writer = new DataWriter();
                writer.ByteOrder = ByteOrder.LittleEndian;
                writer.WriteInt32(resultVal);
    
                // Can get details about the request such as the size and offset, 
                //as well as monitor the state to see if it has been completed/cancelled externally.
                // request.Offset
                // request.Length
                // request.State
                // request.StateChanged += <Handler>
    
                // Gatt code to handle the response
                request.RespondWithValue(writer.DetachBuffer());
            });
        }
    }
