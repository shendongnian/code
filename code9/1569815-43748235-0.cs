    [TestMethod]
    public void test1()
    {
        Item item = new(...);
        var uri = "..";
        var client = new HttpClient();
        var response = client.PostAsJsonAsync(uri, item);
        var itemPreview = response.Result.Content.ReadAsAsync<ItemPreview>();
    
        /*  The things to happen once you have item preview */
    
    }
