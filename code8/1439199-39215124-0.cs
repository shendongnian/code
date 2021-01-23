    [Fact]
    public void TestPost3()
    {   
        var httpContent = new StringContent("{ \"firstName\": \"foo\" }", Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var result = client.PostAsync("http://localhost:17232/api/Transformation/Post3", httpContent).GetAwaiter().GetResult();
    }
    [HttpPost]
    [ActionName("Post3")]
    public void Post3([FromBody]IDictionary<string, string> data)
    {
       // do something
    }
