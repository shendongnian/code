    var myTasks = projects.Select(async project =>
    {
        var url = $"urlOneProject{project.name}{secondPartUrl}?authtoken={authToken}";
        var request = (HttpWebRequest) WebRequest.Create(url);
        request.Accept = "application/json";
        request.ContentType = "application/json";
        using (var response = (HttpWebResponse) (await request.GetResponseAsync()))
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var objText = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<Execs>(objText);
        }
    });
    var execs = (await Task.WhenAll(myTasks))
        .SelectMany(result => result.executions);
