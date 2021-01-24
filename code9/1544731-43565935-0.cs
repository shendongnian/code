    SendReceiveOptions customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
    ConnectionInfo connectionInfo = new ConnectionInfo("192.168.1.105", 5614);
    TCPConnection serverConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);
    var message = "This is a test packet";
    serverConnection.SendObject("PacketPrintToConsole", new PacketPrintToConsole(message));
