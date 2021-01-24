    int const concurrentRequestLimit = 4;
    var semaphore = new SemaphoreSlim(concurrentRequestLimit);
    var firstSensitive = await UrlList
                         .Select(async url => {
                             await semaphore.WaitAsync()
                             try
                             using(var http = new HttpClient()
                             {
                                 var result = await hc.GetAsync(url);
                                 return await result.Content.ReadAsStringAsync();
                             }
                             finally
                                 semaphore.Release();
                         })
                         .SelectMany(downloadTask => downloadTask.ToObservable())
                         .Where(result => result.Contains("sensitive"))
                         .FirstOrDefaultAsync();
    
    if(firstSensitive != null)
        Console.WriteLine("WARNING");
