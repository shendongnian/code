        public void ConnectAndSendMessage(string MessageToSend)
        {
            string localIP = GetIPAddress();
            
            System.Net.Sockets.TcpClient tcpclnt = new System.Net.Sockets.TcpClient();
            
            try
            {
                
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect(localIP, 2400);
                System.Net.Sockets.Socket  socket = tcpclnt.Client;
                
                bool connectionStatus = socket.Connected;
                if (connectionStatus)
                {
                    //Send Message
                    ASCIIEncoding asen = new ASCIIEncoding();
                    //string sDateTime = DateTime.Now.ToString();
                    int SendStatus = socket.Send(asen.GetBytes(MessageToSend + Environment.NewLine));
                }
                Thread.Sleep(2000);
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                if (tcpclnt != null && tcpclnt.Connected )
                    tcpclnt.Close();
            }
        }
