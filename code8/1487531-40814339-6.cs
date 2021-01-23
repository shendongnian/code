    public async Task<int> GetIdAsync(string username) {
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(WebServiceURL);
        var list  = JsonConvert.DeserializeObject<List<dynamic>>(json);
        var obj = list.FirstOrDefault();
        int Id = obj != null ? obj.Id : 0;
        return Id;
    }
