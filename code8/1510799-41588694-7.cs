    // sender.cs
    string meMessage = "network message 1";
    byte[] buffer = ProtocolHelper.PackIntoProtocol(meMessage);
    socket.Send(buffer, 0, buffer.Length, 0);
    
    // receiver.cs
    string message = string.Empty;
    byte[] buffer = new byte[sizeof(int)]; // or simply new byte[4];
    int received = socket.Receive(buffer);
    if(received == sizeof(int))
    {
        int packetLen = BitConverter.ToInt32(buffer);// size of our message
        buffer = new byte[packetLen]; 
        received = socket.Receive(buffer);
        if( packetLen == received ) // we have full buffer
        {
            message = PacketHelper.UnpackProtocol(buffer);
        }
    }
    Console.WriteLine(message); // output: "network message 1"
