    [TestMethod]
    public void TestAllocatedAgency() { 
        //Arrange
        var packet = new Fixture().Create<PrimaryAllocationDP>(); //used AutoFixture here
        var sut = new MyClass();
        var accessor = new PrivateObject(sut);     
        //Act
        accessor.Invoke("SomeMethod", packet);
        //Assert
        Assert.IsNotNull(packet.AllocatedAgency);
    }
