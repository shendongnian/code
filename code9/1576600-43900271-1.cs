    [Test]
    public void AtmShouldChargeClientWhenItHasEnoughMoney()
    {
        var walletMock = new Mock<IWallet>();
        walletMock.Setup(w => w.GetTotalAmount()).Returns(15);
        var personMock = new Mock<Person>(walletMock.Object);
        var atm = new Atm();
    
        atm.ProcessPayment(personMock.Object, 10);
    
        walletMock.Verify(w => w.Remove(10), Times.Once);
    }
