               MemoryStream outFile = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(outFile);
                foreach (string fileN in zipFiles)
                {
                    byte[] fileBytes = File.ReadAllBytes(fileN);
                    writer.Write(BitConverter.GetBytes(fileBytes.Length),0,4);
                    writer.Write(fileBytes, 0, fileBytes.Length);
                }
                FileStream stream = File.OpenRead("filename");
                BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);
                while (stream.Position < stream.Length)
                {
                    int size = reader.ReadInt32();
                    byte[] data = reader.ReadBytes(size);
                }
