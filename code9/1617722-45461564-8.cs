    private async Task<Customer> GetDashboardAsync(string customerId) 
    {
        using (var httpClient = new HttpClient())
        {
            string data = await httpClient.GetStringAsync("http://testurl.com/" + id);
            return new Customer { Id = id, Data = data });
        }
    }
    public async Task<Customer[]> GetDashboardAsync(List<string> customerIds)
    {
        var tasks = customerIds
            .Select(GetDashboardAsync)
            .ToArray();
        return await Task.WhenAll(tasks);
    }
