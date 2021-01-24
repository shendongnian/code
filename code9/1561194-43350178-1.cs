    var files = Directory.GetFiles(myFilesDirectory);
    var listOfTasks = files.Select(ProcessAndValidateAsync);
    await Task.WhenAll(listOfTasks);
    Console.WriteLine("All done!");
    async Task ProcessAndValidateAsync(string file)
    {
      var list = await ProcessMyFileTask(localFile);
      ValidateHexDumps(list, localFile);
    }
