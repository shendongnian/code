    public async Task<string> GetCustomersAsync(string firstname, string lastname)
    {
        using (var client = new HttpClient())
        {
            var content = new StringContent("<soapenv:Envelope xmlns:xsi...", Encoding.UTF8, "application/xml");;
            var response = await client.PostAsync("https://example.com/scripts/WebObj.exe/Client.woa/2/ws/ABC", content);
            return await response.Content.ReadAsStringAsync();
        }
    }
