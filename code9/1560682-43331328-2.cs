    [TestMethod]
    public void _MockEvent() {
        //Arrange
        var mock = new Mock<A>();
        EventArgs<Tuple<Step, string>> mess = null;
        mock.Object.TransferInterruptedEvent += delegate(object sender, EventArgs<Tuple<Step, string>> e) {
            mess = e;
        };
        var step = Step.TransferValidation;
        var errorMsg = "Transfer not valid";
        //Act
        mock.Raise(_ => _.TransferInterruptedEvent += null, new EventArgs<Tuple<Step, string>>(new Tuple<Step, string>(step, errorMsg)));
        //Assert
        Assert.IsNotNull(mess);
        Assert.IsTrue(mess.Value.Item1 == Step.TransferValidation);
        Assert.IsTrue(mess.Value.Item2 == "Transfer not valid");
    }
