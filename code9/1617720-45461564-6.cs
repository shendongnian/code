    private async Task<Customer> GetDashboard(string customerId) 
    {
        using (var httpClient = new HttpClient())
        {
            string data = await httpClient.GetStringAsync("http://testurl.com/" + id);
            return new Customer { Id = id, Data = data });
        }
    }
    public async Task<Customer[]> GetDashboard(List<string> customerIds)
    {
        var tasks = customerIds
            .Select(async (id) => await GetDashboard(id))
            .ToArray();
        return await Task.WhenAll(tasks);
    }
