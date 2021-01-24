    public void TestMethod1()
    {
        List<string> s = new List<string> { "sfas", "asfsa", "blbba" };
        var hit = Isolate.Fake.NextInstance<Hit>();
    
        Isolate.WhenCalled(() => hit.Result).WillReturnCollectionValuesOf(s);
    }
