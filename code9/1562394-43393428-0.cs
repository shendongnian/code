    public static void Server()
    {
        var lst = new List<string> { "Foo", "Bar", "Baz" };
        int port = 15001;
        var localAddr = IPAddress.Parse("127.0.0.1");
        var listener = new TcpListener(localAddr, port);
        try
        {
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                var thread = new Thread(() =>
                {
                    using (client)
                    using (var ns = client.GetStream())
                    using (var br = new BinaryReader(ns, Encoding.ASCII, true))
                    using (var bw = new BinaryWriter(ns, Encoding.ASCII, true))
                    {
                        bw.Write(lst.Count);
                        for (int i = 0; i < lst.Count; i++)
                        {
                            bw.Write(lst[i]);
                        }
                        var lst2 = new List<string>();
                        int count = br.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            lst2.Add(br.ReadString());
                        }
                        foreach (string str in lst2)
                        {
                            Console.WriteLine("Server: {0}", str);
                        }
                    }
                });
                thread.Start();
            }
        }
        finally
        {
            listener.Stop();
        }
    }
    public static void Client()
    {
        Trace.WriteLine("Client");
        int port = 15001;
        var localAddr = IPAddress.Parse("127.0.0.1");
        using (var client = new TcpClient("127.0.0.1", port))
        using (var ns = client.GetStream())
        using (var br = new BinaryReader(ns, Encoding.ASCII, true))
        using (var bw = new BinaryWriter(ns, Encoding.ASCII, true))
        {
            var lst = new List<string>();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                lst.Add(br.ReadString());
            }
            foreach (string str in lst)
            {
                Console.WriteLine("Client: {0}", str);
            }
            bw.Write(lst.Count);
            for (int i = 0; i < lst.Count; i++)
            {
                var chars = lst[i].ToCharArray();
                Array.Reverse(chars);
                bw.Write(new string(chars));
            }
        }
    }
