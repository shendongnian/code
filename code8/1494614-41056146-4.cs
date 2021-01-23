    static void SendAddUserMessageFromSocket(int port, object obj)
    {    
        // simple edit :
        string path = @"path to MyLibrary.dll";
        Assembly library = Assembly.LoadFrom(path);
        Type typeObj = library.GetType("MyLibrary.SendingObject")
        MethodInfo method = typeof(Me.Serialization.Library.MeSerializer).GetMethod("Serialize");
        MethodInfo generic = method.MakeGenericMethod(typeObj);
        byte[] brr = (byte[])generic.Invoke(null, obj); // null because it is static
        // remember to add reference to Me.Serialization.Library
        // byte[] brr = Me.Serialization.Library.MeSerializer.Serialize<MyLibrary.SendingObject>(obj);
        IPHostEntry ipHost = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = ipHost.AddressList[0];
        // skipped rest of the code for readability
    }
