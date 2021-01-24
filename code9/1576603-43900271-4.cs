    [Test]
    public void PersonShouldNotBeChargedWhenThereIsNotEnoughMoneyInWallet()
    {
        var walletMock = new Mock<IWallet>(MockBehavior.Strict);
        walletMock.Setup(w => w.GetTotalAmount()).Returns(5);
        var person = new Person(walletMock.Object);
        person.TryCharge(10).Should().BeFalse();
        walletMock.VerifyAll();
    }
    
    [Test]
    public void PersonShouldBeChargedWhenThereIsEnoughMoneyInWallet()
    {
        var walletMock = new Mock<IWallet>(MockBehavior.Strict);
        walletMock.Setup(w => w.GetTotalAmount()).Returns(15);
        walletMock.Setup(w => w.Remove(10));
        var person = new Person(walletMock.Object);
        person.TryCharge(10).Should().BeTrue();
        walletMock.VerifyAll();
    }
