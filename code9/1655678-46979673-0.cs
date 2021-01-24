    [TestMethod]
    public void TestMethod1()
    {
        XsltConfigSection section = System.Configuration.ConfigurationManager.GetSection("system.xml/xslt") as XsltConfigSection;
        Assert.IsNull(section);
    }
