    private async Task<string> myHttpCall(string path)
    {
        using(HttpClient client = new HttpClient())
        {
               HttpResponseMessage response = await client.GetAsync(path);
               return await response.Content.ReadAsStringAsync();
        }
    }
