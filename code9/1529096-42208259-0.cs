    public partial class CommunicationTCP
    {
       // declare member (field)
       TcpClient tcpclnt;
       public static void Connect()
       {
          // use that field
          tcpclnt = new TcpClient();
          tcpclnt.Connect(ServerIP,ServerPORT);
       }
       public static void TCPSendData()
       {
          // check set the connection has been opened
          if (tcpclnt == null)
              throw new InvalidOperationException("You must open the connection before you can use it!");
          NetworkStream netStream = tcpclnt.GetStream();
          byte[] sendbytes = Encoding.UTF8.GetBytes("COMMAND");
          netStream.Write(sendbytes, 0, sendbytes.Length);
       }
    }
