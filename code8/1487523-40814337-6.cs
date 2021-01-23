    public async Task<int> GetIdAsync(string username)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceURL);
            var  Id  = JsonConvert.DeserializeObject<Rootobject>(json).Property1.FirstOrDefault().Id;
;
           return Id;
    };
