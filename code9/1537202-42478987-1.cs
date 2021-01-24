            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2016);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);
            byte[] data = new byte[1024];
            int recv = client.Receive(data);
            string s = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("From Server : {0}", s);
            string input;
            while (true)
            {
                input = Console.ReadLine();
                data = new byte[1024];
                data = Encoding.ASCII.GetBytes(input);
                client.Send(data, data.Length, SocketFlags.None);
               // data = new byte[1024];
                recv = client.Receive(data);
                s = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("From Server : {0}", s);
                Console.ReadKey();
            }
           
