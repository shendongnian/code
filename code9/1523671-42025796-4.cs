    public async Task<WalmartModel> GetModel(string url, HttpClient client) {
        //GET Method  
        using(var response = await client.GetAsync(url)) {
            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadAsAsync<WalmartModel>();
            } else {
                Console.WriteLine("Internal server Error");
            }
        }         
        return null;       
    }
