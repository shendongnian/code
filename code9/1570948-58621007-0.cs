    public static byte[] Compress(byte[] raw)
    {
        using (MemoryStream memory = new MemoryStream())
        {
            using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
            {
                gzip.Write(raw, 0, raw.Length);
                gzip.Close();
            }
            return memory.ToArray();
        }
    }
