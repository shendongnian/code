    [DataTestMethod]
    [DataRow(typeof(Member), typeof(MemberImpl))]
    public void Test1(Type interfaceType, Type implType)
    {
        object instance = PlanungContribution.Create<interfaceType>();
        var type = instance.GetType();
        Assert.AreEqual(type, implType);
    }
