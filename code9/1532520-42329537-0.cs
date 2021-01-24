     using (MemoryStream ms = new MemoryStream())
                {
                    using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            ZipArchiveEntry readmeEntry = archive.CreateEntry($"text{i}.txt");
                            using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                            {
                                writer.WriteLine("text");
                            }
                        }
    
                    }
                   return File(ms.ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, "Result.zip");
                }
