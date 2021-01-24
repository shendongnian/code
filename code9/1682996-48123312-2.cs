    [TestMethod]
    public void TestSomeClass {
        //Arrange
        var username = "dummy";
        var expected = "some value";
        var mock = new Mock<IUser>();
        //...set any necessary members relevant to the test
        mock.Setup(_ => _.username).Returns(username);
        var subject = new SomeClass(mock.Object);
    
        //Act
        //...invoke member to be tested
        var actual = subject.SomeMethod();
        //Assert
        //...verify actual to expected behavior
        Assert.AreEqual(actual, expected);
    }
