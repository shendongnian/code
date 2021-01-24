    private RfcommDeviceService _service;
    private StreamSocket _socket;
    private async void Initialize()
    {
        // Enumerate devices with the object push service
        var services =
            await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(
                RfcommDeviceService.GetDeviceSelector(
                    RfcommServiceId.ObexObjectPush));
        if (services.Count > 0)
        {
            // Initialize the target Bluetooth BR device
            var service = await RfcommDeviceService.FromIdAsync(services[0].Id);
            // Check that the service meets this App's minimum requirement
            if (SupportsProtection(service) && await IsCompatibleVersion(service))
            {
                _service = service;
                // Create a socket and connect to the target
                _socket = new StreamSocket();
                await _socket.ConnectAsync(
                    _service.ConnectionHostName,
                    _service.ConnectionServiceName,
                    SocketProtectionLevel
                        .BluetoothEncryptionAllowNullAuthentication);
                // The socket is connected. At this point the App can wait for
                // the user to take some action, e.g. click a button to send a
                // file to the device, which could invoke the Picker and then
                // send the picked file. The transfer itself would use the
                // Sockets API and not the Rfcomm API, and so is omitted here for
                // brevity.
            }
        }
    }
    // This App requires a connection that is encrypted but does not care about
    // whether its authenticated.
    private bool SupportsProtection(RfcommDeviceService service)
    {
        switch (service.ProtectionLevel)
        {
            case SocketProtectionLevel.PlainSocket:
                if ((service.MaxProtectionLevel == SocketProtectionLevel
                        .BluetoothEncryptionWithAuthentication)
                    || (service.MaxProtectionLevel == SocketProtectionLevel
                        .BluetoothEncryptionAllowNullAuthentication))
                {
                    // The connection can be upgraded when opening the socket so the
                    // App may offer UI here to notify the user that Windows may
                    // prompt for a PIN exchange.
                    return true;
                }
                else
                {
                    // The connection cannot be upgraded so an App may offer UI here
                    // to explain why a connection won't be made.
                    return false;
                }
            case SocketProtectionLevel.BluetoothEncryptionWithAuthentication:
                return true;
            case SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication:
                return true;
        }
        return false;
    }
    // This App relies on CRC32 checking available in version 2.0 of the service.
    private const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
    private const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
    private const uint MINIMUM_SERVICE_VERSION = 200;
    private async System.Threading.Tasks.Task<bool> IsCompatibleVersion(RfcommDeviceService service)
    {
        var attributes = await service.GetSdpRawAttributesAsync(Windows.Devices.Bluetooth.BluetoothCacheMode.Uncached);
        var attribute = attributes[SERVICE_VERSION_ATTRIBUTE_ID];
        var reader = DataReader.FromBuffer(attribute);
        // The first byte contains the attribute' s type
        byte attributeType = reader.ReadByte();
        if (attributeType == SERVICE_VERSION_ATTRIBUTE_TYPE)
        {
            // The remainder is the data
            uint version = reader.ReadUInt32();
            return version >= MINIMUM_SERVICE_VERSION;
        }
        return false;
    }
    // Click a button to send a image file to the device
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var picker = new FileOpenPicker();
        picker.ViewMode = PickerViewMode.Thumbnail;
        picker.SuggestedStartLocation =
        PickerLocationId.PicturesLibrary;
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".png");
        var file = await picker.PickSingleFileAsync();
        if (file != null)
        {
            DataWriter writer = null;
            try
            {
                writer = new DataWriter(_socket.OutputStream);
                writer.WriteUInt32((uint)file.Name.Length);
                writer.WriteString(file.Name);
                var buffer = await FileIO.ReadBufferAsync(file);
                writer.WriteUInt32(buffer.Length);
                writer.WriteBuffer(buffer);
                await writer.StoreAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            writer.DetachStream();
            writer.Dispose();
        }
    }
