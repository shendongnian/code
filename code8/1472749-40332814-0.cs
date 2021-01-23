    var inputTexts = new BlockingCollection<string>();
    var inputNumbers = new BlockingCollection<string>();
    var readFiles = Task.Run(() =>
    {
        try
        {
            foreach (var file in Directory.EnumerateFiles("path", "searchPattern"))
            {
                string text = File.ReadAllText(file);
                inputTexts.Add(text);
            }
        }
        finally { inputTexts.CompleteAdding(); }
    });
    var processNumbers = Task.Run(() =>
    {
        try
        {
            foreach (var text in inputTexts.GetConsumingEnumerable())
            {
                int result;
                if (int.TryParse(text, out result))
                    inputNumbers.Add(text);
            }
        }
        finally { inputNumbers.CompleteAdding(); }
    });
    var createFiles = Task.Run(() =>
    {
        foreach (var number in inputNumbers.GetConsumingEnumerable())
        {
            string path = ""; // set fileName
            File.WriteAllText(path, number);
        }
    });
    Task.WaitAll(readFiles, processNumbers, createFiles);
