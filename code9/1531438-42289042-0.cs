    public async Task<string> Get(string url)
    {
        Debug.WriteLine($"CHECKING 5000");
        using (var client = new HttpClient())
        {
            Debug.WriteLine($"CHECKING 10000");
            var resp = await client.GetAsync (url);
            //you can replace the if below with response.IsSuccessStatusCode
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Debug.WriteLine($"CHECKING = {resp.StatusCode}");
            }
        }
        return String.Empty;
    }
