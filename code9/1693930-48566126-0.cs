    [Test]
    public void AllModuleBindingsTest()
    {
        var kernel = new StandardKernel(new MyNinjectModule())
        foreach (var binding in new MyNinjectModule().Bindings)
        {
            var result = kernel.Get(binding.Service);
            Assert.NotNull(result, $"Could not get {binding.Service}");
        }
    }
