    private void StartListener()
    {
        List<int> puertos = new List<int>();
    
        puertos.Add(5494);
        puertos.Add(5495);
        puertos.Add(5496);
        puertos.Add(5497);
    
        foreach (int puerto in puertos)
        {
            IPAddress localAddr = IPAddress.Parse(ConfigurationManager.AppSettings["ServerIP"]);
            TcpListener listener = new TcpListener(localAddr, puerto);
            listener.Start();
    
            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(() => Service(listener));
                t.Start();
            }
        }
    
    }
    
    private void Service(TcpListener listener)
    {
        while (true)
        {
            Socket soc = listener.AcceptSocket();
    
            try
            {
    
                byte[] resp = new byte[2000];
                var memStream = new MemoryStream();
                var bytes = 0;
    
                NetworkStream s = new NetworkStream(soc);
                StreamReader sr = new StreamReader(s);
    
                while (true)
                {
                    string trama = "";
                    if (s.CanRead)
                    {
                        do
                        {
                            bytes = s.Read(resp, 0, resp.Length);
                            trama = Util.Util.ByteArrayToHexString(resp);
                        }
                        while (s.DataAvailable);
                    }
    
                    if (trama == "" || trama == null) break;    
                }
                s.Close();
            }
            catch (Exception e) { }
            finally
            {
                soc.Close();
            }
        }
    }
