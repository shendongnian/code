    using (ITestEngine engine = TestEngineActivator.CreateInstance())
    {
        var filterService = engine.Services.GetService<ITestFilterService>();
        var builder = filterService.GetTestFilterBuilder();
        builder.AddTest("UnitTestProject.Class1.Test123");
        var filter = builder.GetFilter();
    
        using (ITestRunner runner = engine.GetRunner(package))
        {
            var result = runner.Run(listener: null, filter: filter);
        }
    }
