    HttpClient client = new HttpClient();
    async Task<IEnumerable<Customer>> GetCustomers(string url) {
        List<Customer> result = new List<Customer>();
        do {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
    
            var response = await response.Content.ReadAsAsync<RootObject>();
            result.AddRange(response.Customers);
            url = response.nextRecords;
        } while(!string.IsNullOrWhitespace(url));
        return result;        
    }
