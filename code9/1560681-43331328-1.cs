    [TestMethod]
    public void TestEvent() {
        //Arrange
        var sut = new A();
        EventArgs<Tuple<Step, string>> mess = null;
        sut.TransferInterruptedEvent += delegate(object sender, EventArgs<Tuple<Step, string>> e) {
            mess = e;
        };
        //Act
        sut.Test();
        //Assert
        Assert.IsNotNull(mess);
        Assert.IsTrue(mess.Value.Item1 == Step.TransferValidation);
        Assert.IsTrue(mess.Value.Item2 == "Transfer not valid");
    }
