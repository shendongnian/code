    [TestMethod]
    public void Test()
    {
      //Arrange
      ICollaborator mock = MockRepository.GenerateMock<ICollaborator>();
      Processor myProc = new Processor(mock, ...);
    
      //Act
      myProc.Process();
    
      //Assert
      mock.AssertWasCalled(x => x.MethodToBeCalled);
    }
