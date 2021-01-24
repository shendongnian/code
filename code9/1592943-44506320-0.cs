     private void ReceiveMessage()
            {
                while (true) {
                    if(_client.Available > 0) {
                        byte[] buffer = new byte[1024];
                        _client.Receive(buffer);
                        Console.WriteLine("A message has been received : " + Encoding.ASCII.GetString(buffer));
                    }
                }
            }
