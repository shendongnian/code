    var lst = new List<Block>();
    var enc = Encoding.GetEncoding("iso-8859-1");
    using (var fs = File.OpenRead("somefile.bin"))
    using (var br = new BinaryReader(fs, enc))
    {
        while (br.PeekChar() != -1)
        {
            var block = new Block();
            block.Timestamp = br.ReadInt64();
            for (int i = 0; i < block.DataBlock1.Length; i++)
            {
                block.DataBlock1[i] = br.ReadBytes(16);
                if (block.DataBlock1[i].Length != 16)
                {
                    throw new Exception();
                }
            }
            for (int i = 0; i < block.DataBlock2.Length; i++)
            {
                block.DataBlock2[i] = br.ReadBytes(16);
                if (block.DataBlock2[i].Length != 16)
                {
                    throw new Exception();
                }
            }
            lst.Add(block);
        }
    }
