    static async Task ExtractJsonsInMemory(string filename, Stream stream, ITargetBlock<string> queue)
            {
                ZipArchive archive = new ZipArchive(stream);
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        using (TextReader reader = new StreamReader(entry.Open(), Encoding.UTF8))
                        {
                            var jsonText = reader.ReadToEnd();
                            await queue.SendAsync(jsonText);
                        }
                    }
                    else if (entry.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        await ExtractJsonsInMemory(entry.FullName, entry.Open(), queue);
                    }
                }
            }
