    public async Task POSTDataHttpContent(string jsonString, string webAddress)
    {
        using (HttpClient client = new HttpClient())
        {
            StringContent stringContent = new StringContent(jsonString);
            HttpResponseMessage response = await client.PostAsync(
                webAddress,
                stringContent);
    
            // Assert your response may be?
        }           
    }
