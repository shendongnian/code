                client.ReceiveTimeout = 3;
                client.SendTimeout = 3;
                byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                Console.WriteLine();
                using (var writer = new BinaryWriter(client.GetStream(),Encoding.ASCII,true))
                {
                    writer.Write(messageInBytes);
                }
                using (var reader = new BinaryReader(client.GetStream(),Encoding.ASCII, true))
                {
                    while (itIsTheEnd == false)
                    {
                        bytes = reader.Read(responseInBytes, 0, responseInBytes.Count());
                        if (lastBytesArray == responseInBytes)
                        {
                            itIsTheEnd = true;
                        }
                        lastBytesArray = responseInBytes;
                        Thread.Sleep(15);
                    }
                }
                response = Encoding.ASCII.GetString(responseInBytes);
