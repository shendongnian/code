    [TestMethod,Isolated]
    public void UrlTest()
    {
        //Arrange 
        var fakeRequest = Isolate.Fake.Instance<RequestContext>();
        Isolate.WhenCalled(() => HttpContext.Current.Request.RequestContext).WillReturn(fakeRequest);
        
        //Act
        var res = new UrlModel();
        //getting the private field so it can be asserted
        var privateField = Isolate.NonPublic.InstanceField(res, "url").Value as UrlHelper;
    
        //Assert
        Assert.AreEqual(fakeRequest, privateField.RequestContext);
    }
