    private StreamSocket _socket;
    private RfcommServiceProvider _provider;
    private async void Initialize()
    {
        // Initialize the provider for the hosted RFCOMM service
        _provider = await RfcommServiceProvider.CreateAsync(RfcommServiceId.ObexObjectPush);
        // Create a listener for this service and start listening
        StreamSocketListener listener = new StreamSocketListener();
        listener.ConnectionReceived += OnConnectionReceivedAsync;
        await listener.BindServiceNameAsync(
            _provider.ServiceId.AsString(),
            SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
        // Set the SDP attributes and start advertising
        InitializeServiceSdpAttributes(_provider);
        _provider.StartAdvertising(listener);
    }
    private const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
    private const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0A;   // UINT32
    private const uint SERVICE_VERSION = 200;
    private void InitializeServiceSdpAttributes(RfcommServiceProvider provider)
    {
        var writer = new Windows.Storage.Streams.DataWriter();
        // First write the attribute type
        writer.WriteByte(SERVICE_VERSION_ATTRIBUTE_TYPE);
        // Then write the data
        writer.WriteUInt32(SERVICE_VERSION);
        var data = writer.DetachBuffer();
        provider.SdpRawAttributes.Add(SERVICE_VERSION_ATTRIBUTE_ID, data);
    }
    private async void OnConnectionReceivedAsync(
               StreamSocketListener listener,
               StreamSocketListenerConnectionReceivedEventArgs args)
    {
        // Stop advertising/listening so that we're only serving one client
        _provider.StopAdvertising();
        listener.Dispose();
        _socket = args.Socket;
        // The client socket is connected. At this point the App can wait for
        // the user to take some action, e.g. click a button to receive a file
        // from the device, which could invoke the Picker and then save the
        // received file to the picked location. The transfer itself would use
        // the Sockets API and not the Rfcomm API, and so is omitted here for
        // brevity.
        var reader = new DataReader(_socket.InputStream);
        bool remoteDisconnection = false;
        // Infinite read buffer loop
        while (true)
        {
            try
            {
                // Based on the protocol we've defined, the first uint is the size of the file name
                uint readLength = await reader.LoadAsync(sizeof(uint));
                // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                if (readLength < sizeof(uint))
                {
                    remoteDisconnection = true;
                    break;
                }
                var nameLength = reader.ReadUInt32();
                readLength = await reader.LoadAsync(nameLength);
                // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                if (readLength < nameLength)
                {
                    remoteDisconnection = true;
                    break;
                }
                var fileName = reader.ReadString(nameLength);
                // The second uint is the size of the file
                readLength = await reader.LoadAsync(sizeof(uint));
                // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                if (readLength < sizeof(uint))
                {
                    remoteDisconnection = true;
                    break;
                }
                var fileLength = reader.ReadUInt32();
                readLength = await reader.LoadAsync(fileLength);
                // Check if the size of the data is expected (otherwise the remote has already terminated the connection)
                if (readLength < fileLength)
                {
                    remoteDisconnection = true;
                    break;
                }
                var buffer = reader.ReadBuffer(fileLength);
                
                // Save the received image file to local folder
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);
                await FileIO.WriteBufferAsync(file, buffer);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                break;
            }
        }
        reader.DetachStream();
        reader.Dispose();
        if (remoteDisconnection)
        {
            _socket.Dispose();
        }
    }
