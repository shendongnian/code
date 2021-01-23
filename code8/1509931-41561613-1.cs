    private async Task<List<TrelloCard>> ProcessJobs(IQueryable<IGrouping<CardGrouping, Job>> jobs)
    {
        List<Task<TrelloCard>> tasks = new List<Task<TrelloCard>>();
    
        foreach (var job in jobs)
        {
            tasks.Add(ProcessCards(job));
        }
        
        var results = await Task.WhenAll(tasks);
        
        return results.ToList();
    }
    
    
    private Task<TrelloCard> ProcessCards(Job job)
    {
        return Task.Run(() =>
        {
            System.Threading.Thread.Sleep(2000);  //Just for examples sake
    
            return new TrelloCard();
        });
    }
