    byte[] lengthAsBytes = new byte[2]; // an int is two bytes
    namedPipeServer.Read(lengthAsBytes, 0, 2);
    int length = BitConverter.ToInt32(lengthAsBytes, 0);
    byte[] bytes = new byte[length];
    namedPipeServer.Read(bytes, 0, length);
