    //THIS TEST METHOD DOESN'T SHOW IN THE TEST EXPLORER DUE TO RETURN VALUE
    [TestMethod]
    public async Task<bool> AuthenticateGoogle()
    {
        string lToken = "[JWT TOKEN HERE]";
        wfUser lUser = new wfUser(_wfContext);
        var lAuthenticateResult = await lUser.wfAuthenticateGoogle(lToken);
        Assert.IsTrue(lAuthenticateResult, "JWT Token Validated");
    
        return true;
    }
