    public void ConnectAndSendMessage(string MessageToSend)
    {
        string localIP = GetIPAddress();
        using (System.Net.Sockets.TcpClient tcpclnt = new System.Net.Sockets.TcpClient())
        {
            try
            {
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect(localIP, 2400);
                using (System.Net.Sockets.Socket socket = tcpclnt.Client)
                {
                    if (socket.Connected)
                    {
                        //Send Message
                        System.Text.ASCIIEncoding asen = new System.Text.ASCIIEncoding();
                        //string sDateTime = DateTime.Now.ToString();
                        int SendStatus = socket.Send(asen.GetBytes(MessageToSend + Environment.NewLine));
                    }
                    System.Threading.Thread.Sleep(2000);
                    tcpclnt.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                if (tcpclnt != null && tcpclnt.Connected)
                    tcpclnt.Close();
            }
        }
    }
