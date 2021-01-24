     foreach (var entry in client.EnumerateDirectory("/Test/"))
                    {
                        StringBuilder lines = new StringBuilder();
                        try
                        {
                            using (Stream fileStream = client.GetReadStream(entry.FullName), zippedStream = new GZipStream(fileStream, CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(zippedStream))
                                {
                                    string line;
                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        lines.AppendLine(line);
                                        Console.WriteLine(lines);
                                    }
                                }
                            }
                        }
    
     
