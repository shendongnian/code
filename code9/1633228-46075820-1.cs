    [DataTestMethod]
    [DataRow(typeof(Member), typeof(MemberImpl))]
    public void Test1(Type interfaceType, Type implType)
    {
        var method = typeof(PlanungContribution).GetMethod("Create").MakeGenericMethod(interfaceType);
        var instance = method.Invoke(null, new object[0]);
        var type = instance.GetType();
        Assert.AreEqual(type, implType);
    }
