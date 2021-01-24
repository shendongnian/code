    [HttpPost]
    [ActionName("getData")]
    public Response getData(string myInts) {
        var myIntsList = JsonConvert.DeserializeObject<List<int>>(myInts);
        // Don't forget error handling!
    }
