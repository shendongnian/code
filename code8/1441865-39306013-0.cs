    class DataReceiver
    {    
     public Delegate MessageReceived(string message);
     pulic MessageReceived MessageReceivedEvent;
     private void Socket;
     private bool IsReceiving;
     public Class DataReceiver(Socket sock)
     {
     Socket = sock;
     }
     public void StartReceiving()
      => Task.Run((Action)ReceiveLoop);
     public void StopReceiving()
      => IsReceiving = false;
     private void ReceiveLoop()
     {
      IsReceiving = true;
      while(IsReceiving)
      {
       byte[] LengthHeader = new byte[4];
       Socket.Receive(LenthHeader, 0, 4);
       byte[] Buffer = new byte[BitConverter.ToInt32(LengthHeader);
       Socket.Receive(Buffer, 0,Buffer.Length);
       MessageReceivedEvent?.Invoke(Encoding.UTF8.GetString(Buffer);
      }
     }          
    }
