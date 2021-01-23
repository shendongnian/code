    public static class ProtocolHelper
    {
        public byte[] PackIntoProtocol(string message)
        {
            List<byte> result = new List<byte>();
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            result.AddRange(BitConverter.GetBytes(messageBuffer.Length), 0); // this is the first part of the protocol ( length of the message )
            result.AddRange(messageBuffer); // this is actual message
            return result.ToArray();
        }
    
        public string UnpackProtocol(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }
