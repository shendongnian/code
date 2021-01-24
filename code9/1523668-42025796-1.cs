    var tasks = new List<Task>();
    tasks.Add(GetModel("**URL 1**"));
    tasks.Add(GetModel("**URL 2**"));
    tasks.Add(GetModel("**URL N**"));
    var responses = await Task.WhenAll(tasks);
    var results = responses.Where(r => r != null);
