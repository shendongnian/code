    public void Send(string message, Socket sock)
    {
      byte[] LengthHeader;
      byte[] Buffer;
      Buffer = Encoding.UTF8.GetBytes(message);
      LengthHeader = BitConverter.GetBytes(Buffer.Length);
      sock.Send(LengthHeader, 0, 4);
      socket.Send(Buffer, 0, Buffer.Length;
    }
