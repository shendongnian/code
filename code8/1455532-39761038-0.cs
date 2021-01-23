    var allTasks = new List<Task>();
    foreach(var payload in payloads)
    {
        allTasks.Add(SendPayloadAsync(payload));
    }
    await Task.WaitAll(allTasks);
    private async Task SendPayloadAsync(Payload payload)
    {
        var personObj = 
            payload["Body"].Where(obj => obj["EntityName"].ToString().Equals("person"))
                           .FirstOrDefault();
        var studyObj = 
            payload["Body"].Where(obj => obj["EntityName"].ToString().Equals("study"))
                           .FirstOrDefault();
        var personId = await _apiService.AddPerson(personObj);
        if(personId != null)
        {
            studyObj["person_id"] = personId;
            var studyId = await _apiService.AddStudy(studyObj);
        }
    }
