    //THIS TEST METHOD SHOWS IN THE TEST EXPLORER
    [TestMethod]
    public async Task AuthenticateGoogle()
    {
        string lToken = "[JWT TOKEN HERE]";
        wfUser lUser = new wfUser(_wfContext);
        var lAuthenticateResult = await lUser.wfAuthenticateGoogle(lToken);
    
        Assert.IsTrue(lAuthenticateResult, "JWT Token Validated");
    }
