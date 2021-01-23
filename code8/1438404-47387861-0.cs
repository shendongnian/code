            public static byte[] Compress(byte[] inputData)
                {
                    if (inputData == null)
                        throw new ArgumentNullException("inputData must be non-null");
        
                    MemoryStream output = new MemoryStream();
                    using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
                    {
                        dstream.Write(inputData, 0, inputData.Length);
                    }
                    return output.ToArray();
        }
    
    OR
    
        
    
    public static byte[] Compress(byte[] inputData)
        {
            if (inputData == null)
                throw new ArgumentNullException("inputData must be non-null");
    
            using (var compressIntoMs = new MemoryStream())
            {
                using (var gzs = new BufferedStream(new GZipStream(compressIntoMs,
                 CompressionMode.Compress), BUFFER_SIZE))
                {
                    gzs.Write(inputData, 0, inputData.Length);
                }
                return compressIntoMs.ToArray();
            }
        }
    
