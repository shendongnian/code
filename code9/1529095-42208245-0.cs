       TcpClient tcpclnt = new TcpClient();
    
       public static void Connect()
       {
          tcpclnt.Connect(ServerIP,ServerPORT);
       }
       public static void TCPSendData()
       {
         NetworkStream netStream = tcpclnt.GetStream();
         byte[] sendbytes = Encoding.UTF8.GetBytes("COMMAND");
         netStream.Write(sendbytes, 0, sendbytes.Length);
       }
