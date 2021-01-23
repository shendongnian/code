                inputBytes = Encoding.UTF8.GetBytes(output);
                using (var outputStream = new MemoryStream())
                {
                    using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                        gZipStream.Write(inputBytes, 0, inputBytes.Length);
                    System.IO.File.WriteAllBytes("file.xml.gz", outputStream.ToArray());
                }
