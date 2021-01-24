        static void EndReceive(IAsyncResult ar)
        {
            var client = (Client)ar.AsyncState;
            var received = 0;
            try
            {
                received = client.socket.EndReceive(ar);
            }
            catch (SocketException ex)
            {
                client.socket.BeginDisconnect(false, (AsyncCallback)EndDisconnect, client);
            }
            
            if (received > 0)
            {
                client.stream.Write(client.buffer, 0, received);
                if (client.socket.Available == 0)
                {
                    var sent = client.stream.ToArray();
                    client.stream.SetLength(0L);
                    Console.WriteLine("Client sent " + sent.Length + " bytes of data");
                }
            }
            try
            {
                client.socket.BeginReceive(client.buffer, 0, client.buffer.Length, SocketFlags.None, (AsyncCallback)EndReceive, client);
            }
            catch (SocketException socketException)
            {
                return;
            }
            catch (ObjectDisposedException disposedException)
            {
                return;
            }
        }
