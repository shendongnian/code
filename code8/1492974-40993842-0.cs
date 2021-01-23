    for(var i = 0;i<doc.GetElementsByTagName("ItemID").Count;i = i+2)
    {
        Parallel.For(0, 2, i => {
            var xmlResponse =    PerformHttpRequestMethod(); 
        });
        Thread.Sleep(2000);
    }
    
