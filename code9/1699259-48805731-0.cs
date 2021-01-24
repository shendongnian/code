    using (var file = File.Open(@"D:\Temp\Temp.zip", FileMode.Open))
    using (var archive = new ZipArchive(file))
    {
        var entry = archive.GetEntry("ttt/README.md");
        using (var entryStream = entry.Open())
        using (var memory = new MemoryStream())
        {
            entryStream.CopyTo(memory);
            Console.WriteLine(Encoding.UTF8.GetString(memory.ToArray()));
        }
    }
