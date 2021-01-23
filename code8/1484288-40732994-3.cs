    //use the Azure AD client library
    string accessToken = "";
    string tenantId = ""; 
    string graphResourceId = "https://graph.windows.net";
    Uri servicePointUri = new Uri(graphResourceId);
    Uri serviceRoot = new Uri(servicePointUri, tenantId);
    ActiveDirectoryClient client = new ActiveDirectoryClient(serviceRoot, async () => await Task.FromResult(accessToken));
 
    foreach(var user in client.Users.ExecuteAsync().Result.CurrentPage)
                Console.WriteLine(user.DisplayName);
    //using the HTTP request 
    var client = new HttpClient();
    var tenantId = "";
    var uri = $"https://graph.windows.net/{tenantId}/users?api-version=1.6";
    var token = "";
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
    var response = client.GetAsync(uri).Result;
    var result = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine(result);
