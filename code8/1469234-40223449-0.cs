    var xmlFiles = new BlockingCollection<XDocument>();
    var readFiles = Task.Run(() =>
    {
        try
        {
            foreach (var file in Directory.EnumerateFiles(".", "*.xml"))
                xmlFiles.Add(XDocument.Load(file));
        }
        finally { xmlFiles.CompleteAdding(); }
    });
    var processFiles = Task.Run(() =>
    {
        foreach (var xml in xmlFiles.GetConsumingEnumerable())
        {
            // Insert data to database
        }
    });
    Task.WaitAll(readFiles, processFiles);
