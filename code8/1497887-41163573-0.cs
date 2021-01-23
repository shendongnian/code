        class MyEncoder : UTF8Encoding
    {
        public MyEncoder()
        {
        }
        public override byte[] GetBytes(string s)
        {
            s = s.Replace("\\", "/");
            return base.GetBytes(s);
       }
    }
    System.IO.Compression.ZipFile.CreateFromDirectory(startpath, zippath, CompressionLevel.Fastest, false, new MyEncoder());                                  
