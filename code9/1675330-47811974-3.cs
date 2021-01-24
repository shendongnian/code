    using (BinaryReader br = new BinaryReader(fs))
    {
        while(br.BaseStream.Position < br.BaseStream.Length)
        {
             Console.WriteLine(br.ReadString());
        }
    }
