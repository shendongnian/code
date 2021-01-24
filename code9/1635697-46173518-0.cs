    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < 1000; i++)
    {
        var httpClient = new HttpClient();
        results[i] = httpClient.GetByteArrayAsync(@"https://www.google.co.il/?gfe_rd=cr&dcr=0&ei=OZy3WcmoMY7b8Affj4F4&gws_rd=ssl");
    }
    var status = Task.WhenAll(results); //WhenAny if you can process results independently
    var pages = status.Result;
    sw.Stop();
    double sec = sw.Elapsed.TotalSeconds;
    Console.WriteLine(sec);
