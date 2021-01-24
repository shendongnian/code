    public static void ReadDataBlock(BinaryReader br, byte[][] dataBlock, int size)
    {
        int totalSize = dataBlock.Length * size;
        byte[] bytes = br.ReadBytes(totalSize);
        if (bytes.Length != totalSize)
        {
            throw new Exception();
        }
        for (int i = 0; i < dataBlock.Length; i++)
        {
            var block = new byte[size];
            dataBlock[i] = block;
            Buffer.BlockCopy(bytes, i * size, block, 0, size);
        }
    }
