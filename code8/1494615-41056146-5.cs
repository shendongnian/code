    // simple edit :
    string path = @"path to MyLibrary.dll";
    Assembly library = Assembly.LoadFrom(path);
    Type typeObj = library.GetType("MyLibrary.SendingObject")
    MethodInfo method = typeof(Me.Serialization.Library.MeSerializer).GetMethod("Deserialize");
    MethodInfo generic = method.MakeGenericMethod(typeObj);
    // remember to add reference to Me.Serialization.Library
    while (!isWorkFinished)
    {
        Socket handler = socketListener.Accept();
        byte[] bytes = new byte[2064];
        // Get data from connected socket to buffer
        int numberOfReceivedBytes = handler.Receive(bytes);
        byte[] bytesObject = new byte[numberOfReceivedBytes];
        for (int i = 0; i < numberOfReceivedBytes; i++)
            bytesObject[i] = bytes[i];
        object brr = (object)generic.Invoke(null, bytesObject);
        // object res = (object)Me.Serialization.Library.MeSerializer.Deserialize<MeLibrary.SendingObject>(bytesObject);
    }
