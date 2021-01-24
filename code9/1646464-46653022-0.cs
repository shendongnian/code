    [Fact]
    public void ReturnSomeMethod_UsingAutoFixtureAutoNSubstitute()
    {
        const int expected = 3;
        var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        fixture.Freeze<IDependency1>().SomeMethod().Returns(expected);
        var target = fixture.Create<MyClass>();
        var actual = target.ReturnSomeMethod();
        Assert.Equal(actual, expected);
    }
