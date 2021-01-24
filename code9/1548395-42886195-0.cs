    static http = new HttpClient(); //reuse httpclient instead of creating a new one each time.
    public async static Task<tubeStatusRootObject[]> GetTubeStatus(string url) {
        var response = await http.GetAsync(url); 
        var json = await response.Content.ReadAsStringAsync(); //This is working
        var data = JsonConvert.DeserializeObject<tubeStatusRootObject[]>(json);
        return data;
    }
