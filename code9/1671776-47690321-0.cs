    class GetSocket
    {     
        public string SocketSendReceive(string server, int port, string cmd)
        {
            byte[] recvBuffer = new byte[1024];
            TcpClient tcpClient = new TcpClient();
            tcpClient.Client.ReceiveTimeout = 200;
            string tmp;
           
                try
                {
                    tcpClient.Connect(server, 6100);
                    
                }
                catch (SocketException e)
                {
                   
                    MessageBox.Show(e.Message);
                }
                if (tcpClient != null && tcpClient.Connected)
                {
                    try
                    {
                        tcpClient.Client.Send(Encoding.UTF8.GetBytes(cmd));
                        tcpClient.Client.Receive(recvBuffer);
                        tmp = Encoding.ASCII.GetString(recvBuffer, 0, recvBuffer.Length);
                        string[] words = tmp.Split(null);
                        return words[1];
                    }
                    catch (SocketException e)
                    {
                        return ("No Answer Received");
                    }
        
                }
            return null;
        }
 
    }
