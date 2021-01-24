    byte[] bytes = new byte[] { 1, 2, 3, 4 };
    int length = bytes.Length;
    byte[] lengthAsBytes = BitConverter.GetBytes(length);
    namedPipeServer.Write(lengthAsBytes, 0, 2); // an int is two bytes
    namedPipeServer.Write(bytes, 0, length);
