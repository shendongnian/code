    public interface IParentService
    {
    	IDependantService Dependant { get; }
    }
    
    public interface IDependantService
    {
    	void Execute();
    }
    
    [Fact]
    //This test passes
    public void VerifyThatNestedMockSetupGeneratesNewMockObject()
    {
    	var value = 0;	
    
    	var parentServiceMock = new Mock<IParentService>();
    	var dependantServiceMock = new Mock<IDependantService>();
    	dependantServiceMock.Setup(x => x.Execute()).Callback(() => { value = 1; });
    
    	parentServiceMock.Setup(x => x.Dependant).Returns(dependantServiceMock.Object);
    
    	Assert.Same(parentServiceMock.Object.Dependant, dependantServiceMock.Object);
    	parentServiceMock.Setup(x => x.Dependant.Execute()).Callback(() => { value = 2; });
    	Assert.NotSame(parentServiceMock.Object.Dependant, dependantServiceMock.Object);
    
    	parentServiceMock.Object.Dependant.Execute();
    
    	Assert.Equal(2, value);
    }
