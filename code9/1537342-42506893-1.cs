    public static async Task<ResponseEntity> GetDataObjects()
    {
        ResponseEntity response = new ResponseEntity();
        var apiKey = "some-api-key";
        var path = "path-to-external-service";
        using (var client = new HttpClient())
        {
            var dataToProcess = // some data object    
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));    
            HttpResponseMessage response = await client.PostAsJsonAsync("", dataToProcess).ConfigureAwait(false);
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);    
            var result = JsonConvert.DeserializeObject<ResponseEntity>(responseString);
    
            return response;
        }
    }
