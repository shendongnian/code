    public static IEnumerable<byte[]> UnpackCompositeFile(string filename)
    {
        using (var fstream = File.OpenRead(filename))
        {
            long offset = 0;
            while (offset < fstream.Length)
            {
                fstream.Position = p;
                byte[] bytes = null;
                using (var ms = new MemoryStream())
                using (var unpack = new Ionic.Zlib.GZipStream(fstream, Ionic.Zlib.CompressionMode.Decompress, true))
                {
                    unpack.CopyTo(ms);
                    bytes = ms.ToArray();
                    // Total compressed bytes read, plus 10 for GZip header, plus 8 for GZip footer
                    offset += unpack.TotalIn + 18;
                }
                yield return bytes;
            }
        }
    }
