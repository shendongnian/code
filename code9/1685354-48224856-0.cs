    using Cudafy;
    using Cudafy.Host;
    using Cudafy.Translator;
    [Cudafy]
    public IEnumerable<Image> SaveImages()
    {
        IEnumerable<Image> source (...)
        MemoryStream ms = new MemoryStream();
    
        foreach (Image img in source)
        {
           img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    
        ms.Close();
        return source;
    }
