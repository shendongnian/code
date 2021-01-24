    public object Any(ClientRequest request)
    {
        // make a request to server X on an authenticated endpoint
        var session = base.SessionAs<AuthUserSession>();
        var client = new JsonServiceClient("http://localhost:8088");
        client.SetSessionId(session.Id);
        var response = client.Post(new Hello {
            Name = "user of server Y"
        });
        return new TwoPhaseResponse { Result = $"Server X says: {response.Result}" };
    }
