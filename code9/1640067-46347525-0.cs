        static void Process(Socket client) {
            Console.WriteLine("Incoming connection from " + client.RemoteEndPoint);
            const int maxMessageSize = 1024;
            byte[] response;
            int received;
            while (true) {
                // Send message to the client:
                Console.Write("Server: ");
                client.Send(Encoding.ASCII.GetBytes(Console.ReadLine()));
                Console.WriteLine();
                // Receive message from the server:
                response = new byte[maxMessageSize];
                received = client.Receive(response);
                if (received == 0) {
                    Console.WriteLine("Client closed connection!");
                    return;
                }
                List<byte> respBytesList = new List<byte>(response);
                respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                Console.WriteLine("Client (" + client.RemoteEndPoint + "+: " + Encoding.ASCII.GetString(respBytesList.ToArray()));
            }
        }
        static void Main(string[] args) {
            int backlog = -1, port = 2222;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ReceiveTimeout = -1;
            // Start listening.
            try {
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(backlog);
            }
            catch (Exception) {
                Console.WriteLine("Listening failed!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Start listening...");
            while(true) {
                Socket client = server.Accept();
                new System.Threading.Thread(() => {
                    try { Process(client); } catch (Exception ex) { Console.WriteLine("Client connection processing error: " + ex.Message); }
                }).Start();
            }
            //Console.WriteLine("Press any key for exit...");
            //Console.ReadKey();
        }
