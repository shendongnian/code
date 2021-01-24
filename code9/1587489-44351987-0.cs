    [TestMethod,Isolated]
    public void TestMethod()
    {
        var fake = Isolate.Fake.Instance<DemoCls>(Members.CallOriginal, ConstructorWillBe.Ignored);
        fake.Execute();
    
        Isolate.Verify.WasCalledWithAnyArguments(() => fake.Execute());
    }
