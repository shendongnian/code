                using (var fileStream = new MemoryStream())
                {
                    client.DownloadFile(file.FullName, fileStream); // Success! All is good here, so far. :)
                    fileStream.Seek(0, SeekOrigin.Begin);
                    using (var gzStream = new GZipStream(fileStream, CompressionMode.Decompress))
                    {
                        using (var outputStream = new MemoryStream())
                        {
                            gzStream.CopyTo(outputStream);
                            byte[] outputBytes = outputStream.ToArray(); // No data. Sad panda. :'(
                            ftpFile.FileContents = Encoding.ASCII.GetString(outputBytes);
                            fileResults.Add(ftpFile);
                        }
                    }
                }
