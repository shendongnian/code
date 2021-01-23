    public bool SendMessageAsList(List<EventData list) 
    {
    while(true)
    {
        var batchList = new List<EventData>();
        for (var i = 0; i < list.Count; i + 100)
        try
        {
            if (i % 10000)
                Thread.Sleep(500);
            batchList = list.Skip(i).Take(100).ToList();
            EventHubClient.SendBatch(batchList);
            // Gets here at success
            list = list.Skip(100).ToList();
            if (batchList.Count < 100)
                break;
        }
        catch (NullReferanceException e)
        {
            Console.WriteLine(e);
            Thread.Sleep(2000)
    }
    }
 
