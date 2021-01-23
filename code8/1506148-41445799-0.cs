    public class Program
    {
        public static readonly int Port = 25565;    
        public static readonly string Localhost = "127.0.0.1";
        public static readonly string Host = "127.0.0.1";
        public static void RunServer()
        {
            // start the server
            IPAddress localAdd = IPAddress.Parse(Localhost);
            TcpListener listener = new TcpListener(localAdd, Port);
            listener.Start();
            Console.WriteLine($"Server: Listening on {localAdd}:{Port}");
            // TODO proper exit from server
            while (true)
            {
                // accept client socket -- note that we handle only one connection at a time
                Socket cliSoc = listener.AcceptSocketAsync().Result;
                Console.WriteLine($"Server: Client socket accepted, from {cliSoc.LocalEndPoint}");
                while (true)
                {
                    if (!cliSoc.Connected)
                        break;
                    int bufLen = 1000;
                    byte[] buf = new byte[bufLen];
                    int read = cliSoc.Receive(buf);
                    if (read == 0)
                        break;
                    string msg = System.Text.Encoding.ASCII.GetString(buf, 0, read);
                    Console.WriteLine($"Server: Read from socket: {read} '{msg}'");
                    string response = "OK";
                    byte[] responseArr = System.Text.Encoding.ASCII.GetBytes(response.ToCharArray());
                    int sent = cliSoc.Send(responseArr);
                    Console.WriteLine($"Server: sent response ({sent} bytes)");
                    
                    cliSoc.Shutdown(SocketShutdown.Both);
                }
                Console.WriteLine($"Server: Client socket closed");
            }
        }
        public static void Connect(string message)
        {
            Task.Run(() => RunServer());
                        
            try
            {
                TcpClient client = new TcpClient();
                client.ConnectAsync(Host, Port).Wait();
                client.NoDelay = true;
                NetworkStream stream = client.GetStream();
                if (stream.CanWrite)
                {
                    Console.WriteLine("Client: You can write to this NetworkStream.");
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(message);
                    writer.Flush();
                    Console.WriteLine($"Client: Wrote to stream ({message}).");
                }
                else
                {
                    Console.WriteLine("Client: Sorry.  You cannot write to this NetworkStream.");
                }
                String responseData = String.Empty;
                Console.WriteLine("Client: Reading");
                if(stream.CanRead)
                {
                    Console.WriteLine("Client: You can read this stream");
                    StreamReader reader = new StreamReader(stream);
                    string recievedData = reader.ReadToEnd();
                    Console.WriteLine($"Client: Read: {recievedData}");
                }
                else
                {
                    Console.WriteLine("Client: Sorry.  You cannot read from this NetworkStream.");
                }
                Console.WriteLine("Client: All completed test");
                stream.Flush();
                //client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
        public static void Main(string[] args)
        {
            Connect("Hi there!");
        }
