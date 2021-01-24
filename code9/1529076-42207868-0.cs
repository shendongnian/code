    [TestMethod]
    public void TestEmptyUrl()
    {
        string url = "";
    
        Assert.IsFalse(UrlUtility.IsValid(url));
    }
    
    [TestMethod]
    public void TestInvalidUrl()
    {
        string url = "bad url";
    
        Assert.IsFalse(UrlUtility.IsValid(url));
    }
    
    [TestMethod]
    public void TestUrlWithInvalidScheme()
    {
        string url = "htt://localhost:4000/api/Test";
    
        Assert.IsFalse(UrlUtility.IsValid(url));
    }
    
    [TestMethod]
    public void TestUrlWithHttpScheme()
    {
        string url = "http://localhost:4000/api/Test";
    
        Assert.IsTrue(UrlUtility.IsValid(url));
    }
    
    [TestMethod]
    public void TestUrlWithHttpsScheme()
    {
        string url = "https://localhost:4000/api/Test";
    
        Assert.IsTrue(UrlUtility.IsValid(url));
    }
