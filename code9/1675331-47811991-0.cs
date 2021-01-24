    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
           using (BinaryReader br = new BinaryReader(fs))
           {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                     Console.WriteLine((char)br.Read());
                }
            }
    }
