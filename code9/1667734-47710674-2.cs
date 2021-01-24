    var client = new AtTaskRestClient(_url); // from the example
    ...
    string[] parameteres =
        {
            $"name={issueName}",
            $"description={description}",
            $"projectID={_projectID}",
            $"sessionID={client.SessionID}",
            $"DE:Contact phone={contactPhone}"
        };
    client.CreateEx(ObjCode.ISSUE, parameteres);
