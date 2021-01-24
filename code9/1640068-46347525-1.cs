        static void WorkWithServer(Socket server) {
            const int maxMessageSize = 1024;
            byte[] response;
            int received;
            while(true) {
                try {
                    // Receive message from the server:
                    response = new byte[maxMessageSize];
                    received = server.Receive(response);
                    if (received == 0) {
                        Console.WriteLine("Server closed connection.");
                        return;
                    }
                    List<byte> respBytesList = new List<byte>(response);
                    respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                    Console.WriteLine("Server: " + Encoding.ASCII.GetString(respBytesList.ToArray()));
                    // Send message to the server:
                    Console.Write("You: ");
                    server.Send(Encoding.ASCII.GetBytes(Console.ReadLine()));
                    Console.WriteLine();
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                    return;
                }
            }
        }
        static void Main(string[] args) {
            IPEndPoint serverEp = new IPEndPoint(IPAddress.Parse("192.168.1.2"), 2222);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ReceiveTimeout = -1;
            // Connect to the server.
            try { server.Connect(serverEp); }
            catch (Exception) {
                Console.WriteLine("Establish connection with server (" + serverEp + ") failed!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Connection with server (" + serverEp + ") established!");
            WorkWithServer(server);
            Console.WriteLine("Press any key for exit...");
            Console.ReadKey();
        }
