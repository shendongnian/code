    private async Task SendValues(byte[] toSend)
    {      
      IBuffer writer = toSend.AsBuffer();
      try
      {
         // BT_Code: Writes the value from the buffer to the characteristic.         
         var result = await gattCharacteristic.WriteValueAsync(writer);
         if (result == GattCommunicationStatus.Success)
         {
            //Use for debug or notyfy
            var dialog = new Windows.UI.Popups.MessageDialog("Succes");
            await dialog.ShowAsync();
         }
         else
         {
            var dialog = new Windows.UI.Popups.MessageDialog("Failed");
            await dialog.ShowAsync();
         }
      }
      catch (Exception ex) when ((uint)ex.HResult == 0x80650003 || (uint)ex.HResult == 0x80070005)
      {
         // E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED or E_ACCESSDENIED
         // This usually happens when a device reports that it support writing, but it actually doesn't.
         var dialog = new Windows.UI.Popups.MessageDialog(ex.Message);
         await dialog.ShowAsync();
      }
   }
