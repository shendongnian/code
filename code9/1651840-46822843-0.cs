    if (!File.Exists(Filepath))
    {
        using (FileStream fs = File.Create(Filepath))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes("Text in the file.");
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }
    }
