    public async Task<int> GetIdAsync(string username) {
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(WebServiceURL);
        var list  = JsonConvert.DeserializeObject<List<dynamic>>(json);
        var obj = list.FirstOrDefault();
        if(obj != null) {
            int id = obj.Id;
            return id;
        }
 
        return -1; // or some value to use as a flag
    }
