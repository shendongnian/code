    [TestMethod]
    public void Connect_FailedThrice_ThreeTries()
    {
         IProtocol provider = Substitute.For<IProtocol>();
         provider.Connect(Arg.Any<string>()).Returns(false);
         var sut = new Device(provider);
         sut.Connect("hello");
         provider.Received(3).Connect(Arg.Any<string>());
    }
