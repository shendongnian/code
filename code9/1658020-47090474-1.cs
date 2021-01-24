    [Fact]
    public void AskTheSut()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var sut = fixture.Create<MyClass>();
        Mock.Get(sut.Service1).Setup(s => s.Whatever()).Returns("foo");
        Mock.Get(sut.Service2).Setup(s => s.Whatever()).Returns("bar");
        Mock.Get(sut.Service3).Setup(s => s.Whatever()).Returns("baz");
        var actual = sut.DoIt();
        Assert.Equal("foobarbaz", actual);
    }
