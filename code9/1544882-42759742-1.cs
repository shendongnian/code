    [TestMethod]
    public void TestMethod()
    {
        TextBox txtBox= new TextBox() { Text = "Test" };
        var mockObj = new Mock<IHaveSomeMethod>();
        mockObj.Setup(x => x.Invoke("SomeMethod", It.IsAny<string>())).Returns(true);
        var sut = new PrivateObject(???someObject???, mockObj); // system under test
        object result = privateObj.Invoke("DoSomething", txtBox, EventArgs.Empty);
        Assert.AreEqual(txtBox.Text, string.Empty);
    }
