    [TestMethod]
    public void SomeTest()
    {
        var vm = new YourViewModel();
        vm.PropertyA = "a";
        Assert.IsNotNull(vm.PropertyA);
    }
