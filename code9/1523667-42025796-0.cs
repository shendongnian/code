    public async Task<WalmartModel> GetModel(string url) {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<WalmartModel>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }         
            return null;       
        }
    }
