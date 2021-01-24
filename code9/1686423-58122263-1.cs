            string sToken = result.AccessToken;
            Microsoft.Graph.GraphServiceClient oGraphClient = new GraphServiceClient(
                        new DelegateAuthenticationProvider((requestMessage) => {
                            requestMessage
                                .Headers
                                .Authorization = new AuthenticationHeaderValue("bearer", sToken);
                return Task.FromResult(0);
            }));
