    [Test]
    public void AtmShouldChargeClientWhenItHasEnoughMoney()
    {
        var clientMock = new Mock<IClient>();
        clientMock.Setup(c => c.TryCharge(10)).Returns(true);
        var atm = new Atm();
        atm.ProcessPayment(clientMock.Object, 10);
        clientMock.VerifyAll();
    }    
