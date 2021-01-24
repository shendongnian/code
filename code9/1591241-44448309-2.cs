        #region Allow client event handlers (bi-directional IPC)
        // Attempt to create a IpcServerChannel so that any event handlers on the client will function correctly
        System.Collections.IDictionary properties = new System.Collections.Hashtable();
        properties["name"] = channelName;
        properties["portName"] = channelName + Guid.NewGuid().ToString("N"); // random portName so no conflict with existing channels of channelName
        System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider binaryProv = new System.Runtime.Remoting.Channels.BinaryServerFormatterSinkProvider();
        binaryProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
        System.Runtime.Remoting.Channels.Ipc.IpcServerChannel _clientServerChannel = new System.Runtime.Remoting.Channels.Ipc.IpcServerChannel(properties, binaryProv);
            System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(_clientServerChannel, false);
        #endregion
