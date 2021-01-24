    [TestMethod]
    public void TestMethod1()
    {
        var fakeLocationMap = Isolate.Fake.Instance<SortedDictionary<string, Location>>();
    
        Isolate.WhenCalled(() => fakeLocationMap.ContainsKey(string.Empty)).WillReturn(true);
    
        var instance = new LocationMapper(fakeLocationMap);
        var res = instance.AddLocation(new Location("a"));
    
        Isolate.Verify.WasNotCalled(() => fakeLocationMap.Add(string.Empty, null));
    }
