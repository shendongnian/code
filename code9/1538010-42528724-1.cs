    [TestClass]
    public class ProcessorTests
    {
      [TestMethod]
      public void Process_GivenNewFoo_CallsNewAction()
      {
        // arrange 'newfoo' condition
    
        // mockout our processor, e.g.
        var mockNewAction = new Mock<INewAction>(); // this is Moq, for others use appropriate syntax, e.g. Substitute.For<INewAction>() for NSubstitute etc.
    
        mockNewAction.Setup(x => x.NewAction()).Verifiable();
        var target = new Processor(null, null, mockNewAction.Object);
    
        target.Process();
    
        mockNewAction.Verify(x => x.NewAction(), Times.Once);
      }
    
      [TestMethod]
      public void Process_GivenNewFoo_False_DoesNotCallNewAction()
      {
        // arrange 'newfoo' condition to be false
    
        // mockout our processor, e.g.
        var mockNewAction = new Mock<INewAction>(); // this is Moq, for others use appropriate syntax, e.g. Substitute.For<INewAction>() for NSubstitute etc.
    
        mockNewAction.Setup(x => x.NewAction()).Verifiable();
        var target = new Processor(null, null, mockNewAction.Object);
    
        target.Process();
    
        mockNewAction.Verify(x => x.NewAction(), Times.Never);
      }
    }
