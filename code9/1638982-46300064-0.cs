      public static void gzipdecompressor()
        {
            byte[] file = File.ReadAllBytes(@"C:\Users\quality_digital_2\Documents\Projects\224.html");
            byte[] decompressed = Decompress(file);
            Console.WriteLine(file.Length);
            Console.WriteLine(decompressed);
            var str = System.Text.Encoding.Default.GetString(decompressed);
            Console.WriteLine(str);
        }
    public static byte[] gzipDecompress(byte[] gzip)
        {
            
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
  
