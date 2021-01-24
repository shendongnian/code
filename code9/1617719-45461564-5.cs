    public Task<List<Customer>> GetDashboard(List<string> customerIds)
    {   
        return Task.Factory.StartNew(() => {
            return customerIds
                .AsParallel()
                .Select(id => {
                     using (var httpClient = new HttpClient())
                     {
                          string data = httpClient.GetString("http://testurl.com/" + id);
                          return new Customer { Id = id, Data = data });
                     }
                 })
                .ToList();     
        });
    }
