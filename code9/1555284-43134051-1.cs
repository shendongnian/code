    try
    {
        var convertedStatus = ConvertAssignmentStatus(assignmentStatus);
        //httpResponse = Put("ASSGN?ID=" + assignmentID + "&status=" + //convertedStatus + "&apiKey=" + ApiKey);
        var http = new HttpClient { BaseAddress =  
                                    new Uri("http://localhost:11111/") };
        //I'm passing the value as query string. See the bellow line
        string apiUrl = "api/ControllerName/ASSGN?ID=" + assignmentID + 
                        "&status=" + convertedStatus + "&apiKey=" + ApiKey";
          
        var _response = http.PutAsJsonAsync(http.BaseAddress + apiUrl, "").Result;
        Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
    }
