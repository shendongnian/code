    public async Task Swap(string subscription, string resourceGroup, string site, string slot) 
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken("XXX", "XXX", "XXX"));
        var url =
                $"https://management.azure.com/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.Web/sites/{site}/applySlotConfig?api-version=2016-08-01";
        var data = new {preserveVnet = true, targetSlot = slot};
        var message = new HttpRequestMessage
        {
            RequestUri = new Uri(url),
            Method = HttpMethod.Post,
            Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        };
        var response = await client.SendAsync(message);
        Console.WriteLine(response.StatusCode);
    } 
