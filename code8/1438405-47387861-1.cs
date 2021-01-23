        public static byte[] Decompress(byte[] inputData)
                {
                    if (inputData == null)
                        throw new ArgumentNullException("inputData must be non-null");
        
                    MemoryStream input = new MemoryStream(inputData);
                    MemoryStream output = new MemoryStream();
                    using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
                    {
                        dstream.CopyTo(output);
                    }
                    return output.ToArray();
        
                    if (inputData == null)
                        throw new ArgumentNullException("inputData must be non-null");
                }
    
    OR
    
        public static byte[] Decompress(byte[] inputData)
                {
                    if (inputData == null)
                        throw new ArgumentNullException("inputData must be non-null");
        
                    using (var compressedMs = new MemoryStream(inputData))
                    {
                        using (var decompressedMs = new MemoryStream())
                        {
                            using (var gzs = new BufferedStream(new GZipStream(compressedMs, CompressionMode.Decompress), BUFFER_SIZE))
                            {
                                gzs.CopyTo(decompressedMs);
                            }
                            return decompressedMs.ToArray();
                        }
                    }
                }
