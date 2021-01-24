    class StreamData
    {
        public NetworkStream netstream;
        public byte[] myReadBuffer;
    }
    class TcpEchoClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting echo client...");
            string ipaddress = "127.0.0.1";
            TcpClient client = null;
            NetworkStream netstream = null;
            try
            {
                client = new TcpClient(ipaddress, 13000);
                netstream = client.GetStream();
            }
            catch
            {
                Console.ReadKey();
                Environment.Exit(0);
            }
            var streamData = new StreamData
            {
                netstream = netstream,
                myReadBuffer = new byte[1024],
            };
            netstream.BeginRead(streamData.myReadBuffer, 0, streamData.myReadBuffer.Length,
                                                       new AsyncCallback(myReadCallBack),
                                                       streamData);
            while (true)
            {
                Console.WriteLine("Message :  ");
                string t = Console.ReadLine();
                Console.WriteLine("\n");
                if (write(t, netstream))
                {
                    Console.WriteLine("Message sent.");
                }
                else
                {
                    Console.WriteLine("Unable to send message.");
                }
            }
        }
        
        static void myReadCallBack(IAsyncResult ar)
        {
            var streamData = (StreamData)ar.AsyncState;
            int bytesRead = streamData.netstream.EndRead(ar);
            var readdata = Encoding.ASCII.GetString(streamData.myReadBuffer, 0, bytesRead);
            //Be aware that this might not be the complete message depending on the size of the message and the buffer size
            Console.WriteLine("You received the following message : " + readdata);
            //Start waiting for more data
            streamData.netstream.BeginRead(streamData.myReadBuffer, 0, streamData.myReadBuffer.Length,
                                                       new AsyncCallback(myReadCallBack),
                                                       streamData);
        }
        static bool write(string dat, NetworkStream stream)
        {
            try
            {
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
                try { writer.WriteLine(dat); }
                catch (IOException) { return false; }
                //if (SHAHash(dat, "DATA") != SHAHash(read(stream), "DATA"))
                //    return false;
            }
            catch (InvalidOperationException) { return false; }
            return true;
        }
    }
