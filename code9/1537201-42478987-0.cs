            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2016);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            Console.WriteLine("waiting...");
            Socket client = server.Accept();
            Console.WriteLine("Accept {0}", client.RemoteEndPoint.ToString());
            string s = "Welcome";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(s);
            client.Send(data, data.Length, SocketFlags.None);
            byte[] gdata = new byte[1024];
            byte[] total = new byte[1024];
            string array;
            while (true)
            {
                int recv = client.Receive(gdata);
                array = Encoding.ASCII.GetString(gdata, 0, recv);
                Console.WriteLine("Client: {0}", array);
                //SUM
                int sum = 0;
                string[] arrListStr = array.Split(',');
                for (int i = 0; i < arrListStr.Length; i++)
                {
                    sum += Int32.Parse(arrListStr[i]);
                }
                array = sum.ToString();
                total = Encoding.ASCII.GetBytes(array);
                client.Send(total, total.Length, SocketFlags.None);
            }
           
        
