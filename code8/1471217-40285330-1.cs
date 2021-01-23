            byte[] data = File.ReadAllBytes(fileName);
            using (FileStream streamToWrite = File.Create(@"D:\temp\encrypted.jpg"))
            using (BinaryWriter writer = new BinaryWriter(streamToWrite))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    writer.Write((byte)(data[i] + ENCRYPE_KEY));
                }
            }
