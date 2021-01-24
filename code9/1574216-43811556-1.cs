    NameValueCollection queryString = new NameValueCollection();
    
    mockedWebClient.Setup(w=>w.QueryString).Return(queryString);
    bool isExpected = false;
    mockedWebClient
        .Setup(w=>w.UploadString("url2","POST","bodyyy"))
        .Callback(() => isExpected = queryString["SomeKey"] == "SomeValue")
        .Return("response");
    
    testibject.SomeMethod();
    
    Assert.IsTrue(isExpected);
