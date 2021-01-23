    public int GetUncompressedSize(string FileName)
    {
       using(BinaryReader br = new BinaryReader(File.OpenRead(pathToFile))
       {
            br.BaseStream.Seek(SeekOrigin.End, -4);
            return br.ReadInt32();
       }
    }
