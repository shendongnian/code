    [TestMethod()]
    public void testMethodEquivalence () {
        val arg1 = TestContext.DataRow["arg1"]
        val arg2 = TestContext.DataRow["arg2"]
        val arg3 = TestContext.DataRow["arg3"]
        MyClass expected = new MyClass();
        MyClass sut = new MyClass();
        Assume.That(sut, Is.EqualTo(expected))
        expected.Method1(arg1, arg2, arg3)
        sut.Method2(arg1, arg2, arg3)
        Assert.That(sut, Is.EqualTo(expected))
    }
