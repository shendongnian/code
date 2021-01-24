    public ActionResult Index2()
    {
        List<Tweet> model = null;
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromMinutes(30);
        var task =
            client.GetAsync(
            "http://jsonplaceholder.typicode.com/posts/")
            .ContinueWith((taskwithresponse) =>
            {
                var response = taskwithresponse.Result;
                var readtask = response.Content.ReadAsAsync<List<Tweet>>();
                readtask.Wait();
                model = readtask.Result;
            });
        task.Wait();
        return View(model);
    }
