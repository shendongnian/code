    Request userStoryRequest = new Request("HierarchicalRequirement");
    userStoryRequest.Workspace = workspaceRef;
    userStoryRequest.Project = projectRef;
    userStoryRequest.Query = new Query("FormattedID", Query.Operator.Equals, "US1");
    userStoryRequest.Fetch = new List<string>(){"Attachments"};
    
    QueryResult userStoryResult = restApi.Query(userStoryRequest);
    foreach(var result in userStoryResult.Results)
    {
        Console.WriteLine("Attachment Count: " + result["Attachments"].Count);
    }
