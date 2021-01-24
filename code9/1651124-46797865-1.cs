    class Server
    {
        static void Main(string[] args)
        {
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(
                "testpipe",
                PipeDirection.InOut,
                NamedPipeServerStream.MaxAllowedServerInstances,
                PipeTransmissionMode.Message))//Set TransmissionMode to Message
            {
                // Wait for a client to connect
                Console.Write("Waiting for client connection...");
                pipeServer.WaitForConnection();
                Console.WriteLine("Client connected.");
                //receive message from client
                var messageBytes = ReadMessage(pipeServer);
                Console.WriteLine("Message received from client: " + Encoding.UTF8.GetString(messageBytes));
                //prepare some response
                var response = Encoding.UTF8.GetBytes("Hallo from server!");
                //send response to a client
                pipeServer.Write(response, 0, response.Length);
                Console.ReadLine();
            }
        }
        private static byte[] ReadMessage(PipeStream pipe)
        {
            byte[] buffer = new byte[1024];
            using (var ms = new MemoryStream())
            {
                do
                {
                    var readBytes = pipe.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, readBytes);
                }
                while (!pipe.IsMessageComplete);
                return ms.ToArray();
            }
        }
    }
