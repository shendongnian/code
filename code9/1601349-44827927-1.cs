    [TestMethod]
    public void Setup_Test() {
        var actual = repository.GetAll();
        CollectionAssert.AreEquivalent(allTestData, actual);
    }
