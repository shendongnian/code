    public class handleClient
    {
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Chat);
            ctThread.Start();
        }
        private void Chat()
        {
            BinaryReader reader = new BinaryReader(clientSocket.GetStream());
            try
            {
                while (true)
                {
                    string message = reader.ReadString();
                    foreach (var client in Program.GetClients())
                    {
                        BinaryWriter writer = new BinaryWriter(client.GetStream());
                        writer.Write(message);
                    }
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine($"client disconnecting: {clientSocket.Client.RemoteEndPoint}");
                clientSocket.Client.Shutdown(SocketShutdown.Both);
            }
            catch (IOException e)
            {
                Console.WriteLine($"IOException reading from {clientSocket.Client.RemoteEndPoint}: {e.Message}");
            }
            clientSocket.Close();
            Program.RemoveClient(clientSocket);
            Console.WriteLine($"{Program.GetClientCount()} clients connected");
        }
    }
