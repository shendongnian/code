    HttpClient client = new HttpClient();
    async Task<IEnumerable<Customer>> GetCustomers(string url) {
        var result = new List<Customer>();
        do {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
    
            var body = await response.Content.ReadAsAsync<RootObject>();
            result.AddRange(body.Customers);
            url = response.nextRecords;
        } while(!string.IsNullOrWhitespace(url));
        return result;        
    }
