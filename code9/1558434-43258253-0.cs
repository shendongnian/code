    [SetUp]
    public void Setup()
    {
        var cats = TestContext.CurrentContext.Test?.Properties["Category"];
        foreach (var cat in cats)
        {
            TestContext.WriteLine("Category: " + cat);
        }
    }
    [Test]
    [Category("One")]
    [Category("Two")]
    public void TestMethod()
    {
        Assert.Pass("Passes");
    }
