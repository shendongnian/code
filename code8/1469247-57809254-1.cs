    //Client.cs:134
    //some keys are missing or mispelled
    HttpResponseMessage response = connector.Post(PrepareUrl("issue-token"), null,
    PrepareParams(new Dictionary<string, object>() {
    	{ "username", emailOrUsername },
    	{ "password", password },
    	{ "client_name", clientName },
    	{ "client_vendor", clientVendor },
    	{ "readOnly", readOnly.ToString() }
    }));
