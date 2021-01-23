    for(int i = 0; i < doc.GetElementsByTagName("ItemID").Count; ++i)
    {
        var xmlResponse = PerformHttpRequestMethod();
        if (i % 2 == 0)
        {
          System.Threading.Thread.Sleep(TimeSpan.FromMinutes(2));
        }
    }
