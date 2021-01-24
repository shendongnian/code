    // request token
    var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
    var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");
    if (tokenResponse.IsError)
    {
        Console.WriteLine(tokenResponse.Error);
        return;
    }
    Console.WriteLine(tokenResponse.Json);
    Console.WriteLine("\n\n");
