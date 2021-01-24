    
    Microsoft.Graph.GraphServiceClient graphClient =
        new Microsoft.Graph.GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
        {
            requestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", "{your-access-token}");
            return Task.FromResult(0);
        }));
    
    Microsoft.Graph.User user = await graphClient.Me.Request().GetAsync();
