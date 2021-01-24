    [TestMethod] 
    public void RetrieveSaveDeleteMRR()
    {    
    	// Arange
    	int expected = 1;
    	Moq.Mock<IDelete> deleteObjectMock = new Moq.Mock<IDelete>();
    	deleteObjectMock.Setup(x => x.DeleteFunction(It.IsAny<int>())).Returns(1000);
    	Mrr testedObject = new Mrr(deleteObjectMock.Object);
    
        // Act
    	int actual = testedObject.Delete(10);
    	
    	// Assert
    	Assert.AreEqual(expected, actual);
    }
