    var firstSensitive = await UrlList
                         .Select(async url => {
                             using(var http = new HttpClient()
                             {
                                 var result = await hc.GetAsync(url);
                                 return await result.Content.ReadAsStringAsync();
                             }
                         })
                         .SelectMany(downloadTask => downloadTask.ToObservable())
                         .Where(result => result.Contains("sensitive"))
                         .FirstOrDefaultAsync();
    
    if(firstSensitive != null)
        Console.WriteLine("WARNING");
