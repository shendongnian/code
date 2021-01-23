     using (TcpClient newclient = new TcpClient("192.168.0.151", 4000))
     {
         NetworkStream ns = newclient.GetStream();
         byte[] outbytes = Encoding.ASCII.GetBytes(command);
         ns.Write(outbytes, 0, outbytes.Length);
         ns.Close();
         newclient.Close();
     }
