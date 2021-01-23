    public static void DecompressAndDeserialize(string path)
    {
        using (FileStream originalFileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            FileInfo fileToDecompress = new FileInfo(path);
            string FileName = fileToDecompress.FullName;
            string newFileName = FileName.Remove(FileName.Length - fileToDecompress.Extension.Length);
            using (FileStream decompressedFileStream = File.Create(newFileName))
            {
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedFileStream);
                }
            }
            FileStream fs = new FileStream(newFileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            object[] uploadObject = (object[])formatter.Deserialize(fs);
        }
    }
