    NetworkStream broadcastStream = statusSocket.GetStream();
    Byte[] broadcastBytes = SerializerDeserializerExtensions.Serializer(scannerCl);
    var lengthBytes = BitConverter.GetBytes(broadcastBytes.Length);
    if (!BitConverter.IsLittleEndian)
         Array.Reverse(lengthBytes);
    broadcastStream.Write(lengthBytes, 0, lengthBytes.Length);
    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
    broadcastStream.Flush();
