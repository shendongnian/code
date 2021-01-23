    public static async Task process_urls()
    {
        var urls = System.IO.File.ReadAllLines("urls.txt");
        var allTasks = new List<Task>();
        var throttler = new SemaphoreSlim(initialCount: 5);
        foreach (var urlGroup in SplitToGroupsOfFive(urls))
        {
            var tasks = new List<Task>();
            foreach(var url in urlGroup)
            {
                var task = ProcessUrl(url);
                tasks.Add(task);
            }
            // This delay will sure that next 5 urls will be used only after 1 seconds
            tasks.Add(Task.Delay(1000));
            await Task.WhenAll(tasks.ToArray());
        }
    }
    private async Task ProcessUrl(string url)
    {
        using (var client = new HttpClient())
        {
            var xml = await client.GetStringAsync(url);
            //do some processing on xml output
        }
    }
