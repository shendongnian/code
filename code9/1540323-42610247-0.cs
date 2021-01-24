    [TestMethod]
    public void TestMethod1()
    {
        List<B> fakeList = new List<B> { new B(DateTime.Now), new B(new DateTime(1956, 01, 21)) };
        var classA = Isolate.Fake.Instance<A>(Members.CallOriginal,ConstructorWillBe.Ignored);
        
        var fakePrivate = Isolate.NonPublic.InstanceField(classA, "_list");
        fakePrivate.Value = fakeList;
    
        classA.AddNewB(DateTime.MaxValue);
    
        var res = classA.GetAllBs();
    
        Assert.AreEqual(3, res.Count);
    }
