     Dictionary<string, TCPClient> dictionary = new Dictionary<string, TCPClient>();
    
     
     public static void ClientHandler(object c)
        {
            TcpClient client = (TcpClient)c;
            NetworkStream netstream = client.GetStream();
            bool connected = true;
            while (connected)
            {
                Thread.Sleep(10);
                try
                {
                    byte[] bytes = new byte[client.ReceiveBufferSize];
                       
                    //read the identifier from client
                    netstream.Read(bytes, 0, bytes.Length);
                    
                    String id = System.Text.Encoding.UTF8.GetString(bytes);
                     
                    //add the entry in the dictionary
                    dictionary.Add(id, client);
                    Console.WriteLine("got data");
                    netstream.Write(bytes, 0, bytes.Length);
    
                }
                catch (Exception e)
                {
                    connected = false;
                    Console.WriteLine(e);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
