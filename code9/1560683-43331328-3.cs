    [TestMethod]
    public void _MockEvent() {
        //Arrange
        var mock = new Mock<A>();
        mock.CallBase = true;
        EventArgs<Tuple<Step, string>> mess = null;
        mock.Object.TransferInterruptedEvent += delegate(object sender, EventArgs<Tuple<Step, string>> e) {
            mess = e;
        };
        //Act
        mock.Object.Test();
        //Assert
        Assert.IsNotNull(mess);
        Assert.IsTrue(mess.Value.Item1 == Step.TransferValidation);
        Assert.IsTrue(mess.Value.Item2 == "Transfer not valid");
    }
