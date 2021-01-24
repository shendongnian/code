var discoveryClient = new DiscoveryClient("http://localhost:5000");
discoveryClient.Policy.RequireHttps = false;
var doc = await discoveryClient.GetAsync();
var parameters = new Dictionary<string, string>();
parameters.Add("scope", "MyScope");
parameters.Add("client_secret", "SomeSecret");
parameters.Add("UserName", "UserName");
parameters.Add("Password", "Password");
var tokenResponse = await client.RequestTokenAsync(new TokenRequest
{
       Address = tokenEndpoint,
       ClientId = "your client",
       GrantType = "custom",
       Parameters = parameters
});
