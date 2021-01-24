    using(var client = new HttpClient()) {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var tasks = new List<Task<WalmartModel>>();
        tasks.Add(GetModel("**URL 1**", client));
        tasks.Add(GetModel("**URL 2**", client));
        tasks.Add(GetModel("**URL N**", client));
    
        var responses = await Task.WhenAll(tasks);
    
        var results = responses.Where(r => r != null);
    }
