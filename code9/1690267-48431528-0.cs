    var graphServiceClient = new GraphServiceClient(
        new DelegateAuthenticationProvider((requestMessage) => {
            requestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.access_token);
    
            return Task.FromResult(0);
        })
    );
