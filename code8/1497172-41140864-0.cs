    private async Task SendStressRequests()
    {
        var tasks = new List<Task>();
        for (int i = 0; i < 4000; i++)
        {
            var task = SendApiRequestAsync();
            tasks.Add(task);
        }
        await Task.WhenAll(tasks);
        // Update UI with results
    }    
