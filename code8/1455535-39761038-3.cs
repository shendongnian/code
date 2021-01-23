    var allTasks = new List<Task>();
    foreach(var payload in payloads)
    {
        allTasks.Add(SendPayloadAsync(payload));
    }
    await Task.WhenAll(allTasks);
    private async Task SendPayloadAsync(Payload payload)
    {
        var personObj = 
          payload["Body"].FirstOrDefault(obj => obj["EntityName"].ToString().Equals("person"));
        var studyObj = 
          payload["Body"].FirstOrDefault(obj => obj["EntityName"].ToString().Equals("study"));
        var personId = await _apiService.AddPerson(personObj);
        if(personId != null)
        {
            studyObj["person_id"] = personId;
            var studyId = await _apiService.AddStudy(studyObj);
        }
    }
