        using (BinaryReader br = new BinaryReader(fs))
        {
            var totalLength = br.BaseStream.Length / sizeof(char);
            for (int i = 0; i < totalLength; i++)
            {
                Console.WriteLine(br.ReadString());
            }
        }
