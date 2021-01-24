    private IEnumerable<string> ListOfTestData =>
        new List<string> {
            "test1",
            "test2"
        };
    [DataTestMethod]
    [DynamicData (nameof (ListOfTestData))]
    public void TestMethod(string test) {
        Assert.AreEqual("test", test);
    }
