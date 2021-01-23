    [TestMethod]
    public void ConfirmText()
    {
        TestViewModel testViewModel= new TestViewModel (null, null, null);
        var result = testViewModel.GetType()
        .InvokeMember("ConfirmText",
         BindingFlags.GetProperty |
         BindingFlags.NonPublic |
         BindingFlags.Instance,
         null,
         testViewModel,
         null);
        Assert.AreEqual("Confirm", result);
    }
