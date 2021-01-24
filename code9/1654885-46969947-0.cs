        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            var selection = ConnectDevices.SelectedItems;
            var entry = (DeviceListEntry)selection[0];
            var device = entry.DeviceInformation;
            localSettings.Values["SelectedUsbDeviceId"] =  device.Id;
            localSettings.Values["SelectedUsbDeviceName"] = device.Name;
        }
        private void RetrieveButton_Click(object sender, RoutedEventArgs e)
        {
            Object deviceId = localSettings.Values["SelectedUsbDeviceId"];
            Object deviceName = localSettings.Values["SelectedUsbDeviceName"];
        }
