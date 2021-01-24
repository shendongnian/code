       public async Task<T> GetContentAsync<T>(HttpClient client)
                {
                     string url = $"/mykey/key01";
    
            using (var httpResponse = await client.GetAsync(url))
            {
                httpResponse.EnsureSuccessStatusCode();
                string responsContent = await httpResponse.Content.ReadAsStringAsync();
                return Deserialize<T>(json);
            }
                }
     private T Deserialize<T>(string json)
            {
                return JsonConvert.DeserializeObject<T>(json, SerializationSettings);
            }
