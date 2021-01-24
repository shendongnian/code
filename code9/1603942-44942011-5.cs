    class Program
    {
        private static readonly object _lock = new object();
        private static bool _closed;
        public static void Write(TcpClient client)
        {
            try
            {
                string str;
                SocketShutdown reason = SocketShutdown.Send;
                while ((str = Console.ReadLine()) != "")
                {
                    lock (_lock)
                    {
                        BinaryWriter writer = new BinaryWriter(client.GetStream());
                        writer.Write(str);
                        if (_closed)
                        {
                            // Remote endpoint already said they are done sending,
                            // so we're done with both sending and receiving.
                            reason = SocketShutdown.Both;
                            break;
                        }
                    }
                }
                client.Client.Shutdown(reason);
            }
            catch (IOException e)
            {
                Console.WriteLine($"IOException writing to socket: {e.Message}");
            }
        }
        public static void Read(TcpClient client)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        BinaryReader reader = new BinaryReader(client.GetStream());
                        Console.WriteLine(reader.ReadString());
                    }
                    catch (EndOfStreamException)
                    {
                        lock (_lock)
                        {
                            _closed = true;
                            return;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"IOException reading from socket: {e.Message}");
            }
        }
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 14000);
            Thread writeThread = new Thread(() => Write(client));
            Thread readThread = new Thread(() => Read(client));
            writeThread.Start();
            readThread.Start();
            writeThread.Join();
            readThread.Join();
            client.Close();
            Console.WriteLine("client exiting");
        }
    }
