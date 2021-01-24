    //Use a single client to make the calls.
    using(var client = new HttpClient()) {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //create the search tasks to be executed
        var tasks = new []{
            GetModel("**URL 1**", client),
            GetModel("**URL 2**", client),
            GetModel("**URL N**", client),
        };
        // Await the completion of all the running tasks. 
        var responses = await Task.WhenAll(tasks); // returns IEmumerable<WalmartModel>
    
        var results = responses.Where(r => r != null); //filter out any null values
    }
