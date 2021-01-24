     public string TestMe(SomeData data)
     {
         ITreasure treasure = new Factory().Get(data);
    
         if (treasure is BlueTreasure) { return "blue"; }
         else if (treasure is RedTreasure) { return "red"; }
         else if (treasure is GreenTreasure) { return "green"; }
         return null;
     }
     [TestMethod,Isolated]
    public void TestMethod1()
    {
        var fakeFactory = Isolate.Fake.AllInstances<Factory>();
        var green = new GreenTreasure();
    
        Isolate.WhenCalled(() => fakeFactory.Get(null)).WillReturn(green);
    
        var res = new CantModify().TestMe(new SomeData());
    
        Assert.AreEqual("green", res);
    }
