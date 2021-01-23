    async Task<int> processFiles()
    {
        var processingTasks = new List<Task>();
        foreach (string fileName in listBox1.Items)
        {
              processingTasks.Add(process(fileName));
        }
        await Task.WhenAll(processingTasks);
        return processingTasks.Count;
    }
