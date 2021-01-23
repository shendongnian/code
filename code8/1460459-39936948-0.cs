    using (TcpClient client = new TcpClient("10.1.13.102", 2111))
    {
       using (NetworkStream stream = client.GetStream())
       {
          byte[] sentData = System.Text.Encoding.ASCII.GetBytes("<STX>sRN eExtIn1<ETX>");
          stream.Write(sentData, 0, sentData.Length);
    
          byte[] buffer = new byte[32];
          int bytes;
          if (client.Connected)
          {
             int bytesRead = 0;
             while (bytesRead < buffer.Length)
             {
                 while ((bytes = stream.Read(buffer, 0, buffer.Length)) != 0)
                 {
                    for (int i = 0; i < bytes; i++)
                    {
                       responseData += (char)buffer[i];
                    }
                    bytesRead += bytes;
                 }
             }
          }
       }
    }
