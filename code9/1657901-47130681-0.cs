    AssetManager assets = this.Assets;
    using (StreamReader sr = new StreamReader(assets.Open("myFile.dat")))
    {
         byte[] bytes = default(byte[]);
         using (var memstream = new MemoryStream())
         {
             sr.BaseStream.CopyTo(memstream);
             bytes = memstream.ToArray();
         }
    }
