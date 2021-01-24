    public async Task PostInventory(string jsonInventory, int tenantId)
    {
        var url = "http://localhost:51411/api/MobileAPI/Inventory?TenantId=" + tenantId;
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(jsonInventory, Encoding.UTF8, "text/plain");
            await client.SendAsync(request);
        }
    }
