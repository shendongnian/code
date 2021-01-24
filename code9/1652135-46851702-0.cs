    [TestMethod]
    public void ReadJsonVerifyTypeReturned()
    {
        var testJson = CreateJsonString();
        var result = JsonConvert.DeserializeObject<ProbeResponseData>(testJson);
        var resultCheck = result as ProbeResponseData;
        Assert.IsNotNull(resultCheck);
    }
