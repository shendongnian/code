    [TestMethod]
    public void CanGetSetting()
    {
        var helper = new SettingsTestHelper("default");
        var result = ClasThatImplementsYourStaticMethod.GetDefaultName(helper, true);
        Assert.AreEqual(expected, actual);
    }
