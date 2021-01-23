    [TestMethod]
    public void Test()
    {
        // Arrange
    	var messageBox = new Mock<IMessageBox>();
    	messageBox
    		.Setup(m =>
    			m.Show("TEST))
    		.Verifiable();
    		
    	var sut = new SUT(messageBox.Object);
    	
        // Act
    	sut.Test();
        // Verify
    	messageBox.Verify();		
    }
