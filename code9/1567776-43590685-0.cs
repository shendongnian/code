    static private TcpListener server = null;
        static private Decode oDecode = new Decode();
        static private string sLeftOver = string.Empty;
        static void Main(string[] args)
        {
            Int32 port = 31001;
            //IPAddress localAddr = IPAddress.Parse("74.208.79.132"); //Remote
            IPAddress localAddr = IPAddress.Parse("192.168.0.78"); //Local
            server = new TcpListener(localAddr, port);
            server.Start();
            while (true)
            {
                Console.Write("Waiting for a connection...-- ");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("new client connected");
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(HandleClient), client);
                }
                catch (Exception ex)
                { }
            }
        }
        static void HandleClient(object tcpClient)
        {
            TcpClient client = (TcpClient)tcpClient;
            Byte[] bytes = new Byte[256];
            String data = null;
            int i;
            try
            {
                NetworkStream stream = client.GetStream();
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    URLObject oU = new URLObject();
                    
                    Console.WriteLine(data);
                    Console.WriteLine("");
                    //Split data here
                    string[] aData = Regex.Split(data, @"(?<=[#])");
                    foreach (string s in aData)
                    {
                        string sData = s;
                        sData = sLeftOver + sData;
                        if (sData.EndsWith("#"))
                        {
                            sLeftOver = string.Empty;
                            Console.WriteLine(sData);
                            Console.WriteLine("");
                            oU = oDecode.TextFrameDecode(sData);
                                                    }
                        else
                        {
                            sLeftOver = s;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
