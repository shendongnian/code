    HttpClient client = new HttpClient();
    public string GetResponseString() {
        var request = "http://localhost:51843/api/values/getMessage?id=1";
        var response = client.GetAsync(request).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        return content;
    }
