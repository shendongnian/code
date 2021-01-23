    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri("/path/to/data");
            
    var tasks = new Task<Task<HttpResponseMessage>>[5];
            
    for (var i = 0; i < tasks.Length; i++)
    {
        tasks[i] = Task<Task<HttpResponseMessage>>.Factory.StartNew(async () => await httpClient.GetAsync("?updatedFilterParams"));
    }
    Task.WhenAll(tasks); // wait for them to complete
    foreach (var task in tasks)
    {
        var data = task.Result.Result.Content.ReadAsStringAsync();
            // do something
    }
