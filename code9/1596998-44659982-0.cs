    var taskList = new List<Task<string>>();
    foreach (dynamic i in jira_keys)
    {
        issue_id = i.key;
        string rest_api_url = "some valid url" + issue_id;
        var jiraDownloadTask = Task.Factory.StartNew(() => client.DownloadString(rest_api_url));
        taskList.Add(jiraDownloadTask);
    }
    Task.WaitAll(taskList.ToArray());
    
    //access the results
    foreach(var task in taskList)
    {
        Console.WriteLine(task.Result);
    }
 
