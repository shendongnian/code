    try
    {
         listen = new TcpListener(myAddress, port);
         listen.Start();
         Byte[] bytes;
         while (true)
         {
             TcpClient client = listen.AcceptTcpClient();
             NetworkStream ns = client.GetStream();
             if(client.RecieveBufferSize > 0){
                 bytes = new byte[client.ReceiveBufferSize];
                 ns.Read(bytes, 0, client.ReceiveBufferSize);             
                 string msg = Encoding.ASCII.GetString(bytes); //the message incoming
                 MessageBox.Show(msg);
             }
          }
    }
    catch(Exception e)
    { 
      //e
    }
