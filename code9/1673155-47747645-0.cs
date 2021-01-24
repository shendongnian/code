    private async void InitializeRfcommServer()
    {
        try
        {
            string device1 = RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort);
            deviceCollection = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(device1);
            selectorComboBox.ItemsSource = deviceCollection;
        }
        catch (Exception exception)
        {
            errorStatus.Visibility = Visibility.Visible;
            errorStatus.Text = exception.Message;
        }
    }
