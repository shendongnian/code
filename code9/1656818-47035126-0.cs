      HttpClient client = new HttpClient();
              
                using (var stream = await client.GetStreamAsync(url))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        Console.WriteLine("Download Started");
                        totalBytes = client.MaxResponseContentBufferSize;
    
                        for (; ; )
                        {
                            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                            {
                                await Task.Yield();
                                break;
                            }
    
                            receivedBytes += bytesRead;
    
                            int received = unchecked((int)receivedBytes);
                            int total = unchecked((int)totalBytes);
    
                            double percentage = ((float)received) / total;
                            Console.WriteLine(received / (1024) + "Kb / " + total / (1024 )+" Kb");
                            Console.WriteLine("Completed : " + percentage + "%");
                        }
                    }
                }
