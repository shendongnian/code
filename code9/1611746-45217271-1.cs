    [TestMethod]
    public void TestMethod()
    {
        //setting up test
        var boo = new Mock<IBoo>();
        var goo = new Mock<IGoo>();
        var foo = new Foo(boo.object,goo.object);
        boo.Setup(x=>x.Method(1,2)).Returns(10);
        //running test
        var result = foo.MethodToTest(1,2);
        //verify the test
        Assert.AreEqual(12,result);
    }
