    static void SendAddUserMessageFromSocket(int port, object obj)
    {    
        // remember to add reference to Me.Serialization.Library
        byte[] brr = Me.Serialization.Library.MeSerializer.Serialize<MyLibrary.SendingObject>(obj);
        IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = ipHost.AddressList[0];
        // skipped rest of the code for readability
    }
