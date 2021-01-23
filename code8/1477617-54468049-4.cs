    var client = new System.Net.Http.HttpClient();
    string response = string.Empty;
    string authHeader = string.Empty;
    authHeader = GenerateMasterKeyAuthorizationSignature(verb, resourceId, resourceType, key, keyType, tokenVersion);
    client.DefaultRequestHeaders.Add("x-ms-date", utc_date);
    client.DefaultRequestHeaders.Add("x-ms-version", "2017-02-22");
    client.DefaultRequestHeaders.Remove("authorization");
    client.DefaultRequestHeaders.Add("authorization", authHeader);
