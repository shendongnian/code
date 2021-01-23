    [TestCase(typeof(SomeException))]
    [TestCase(typeof(SomeOtherException))]
    public void UnitTest(Type exceptionType)
    {
        Assert.That(()=>_businessService.Setup(x=>x.DoWork),
            Throws.InstanceOf(exceptionType));
    }
Did I misunderstand the problem?
