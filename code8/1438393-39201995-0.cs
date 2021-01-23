    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost/MyService/Tasks.svc/");
    
    var url = string.Format("CreateTask?t={0}&ud={1}", token, userData);
    
    var myObject = (dynamic)new JObject();
    myObject.title = title;
    myObject.assigneeUsername = assigneeUsername;
    myObject.instructions = instructions;
    myObject.taskNumber = taskNumber;
    myObject.priority = priority;
    
    HttpResponseMessage response = client.PostAsync(url, new StringContent(myObject.ToString(), Encoding.UTF8, "application/json")).Result;
