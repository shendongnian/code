    byte[] lengthAsBytes = new byte[4]; // an int is four bytes
    namedPipeServer.Read(lengthAsBytes, 0, 4);
    int length = BitConverter.ToInt32(lengthAsBytes, 0);
    byte[] bytes = new byte[length];
    namedPipeServer.Read(bytes, 0, length);
