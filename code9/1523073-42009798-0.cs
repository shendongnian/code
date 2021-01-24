    [TestMethod]
    public void TestMethod2()
    {
        int value = 40;
        var foo = new Foo();
        PrivateType privateType = new PrivateType(typeof(Foo));
        MethodInfo fooMethod = foo.GetType().GetMethod("TestThisMethod2", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
        if (fooMethod == null)
        {
            Assert.Fail("Could not find method");
        }
        MethodInfo genericFooMethod = fooMethod.MakeGenericMethod(typeof(int));
        int result1 = (int)genericFooMethod.Invoke(typeof(int), new object[] { value });
        Assert.AreEqual(result1, value);
    }
