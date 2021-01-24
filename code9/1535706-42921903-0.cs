    void CompressFolder(string folder, string targetFilename)
    {
        bool zipping = true;
        long size = Directory.GetFiles(folder).Select(o => new FileInfo(o).Length).Aggregate((a, b) => a + b);
    
        Task.Run(() =>
        {
            ZipFile.CreateFromDirectory(folder, targetFilename, CompressionLevel.NoCompression, false);
            zipping = false;
        });
    
        while (zipping)
        {
            if (File.Exists(targetFilename))
            {
                var fi = new FileInfo(targetFilename);
                System.Diagnostics.Debug.WriteLine($"Zip progress: {fi.Length}/{size}");
            }
        }
    }
