    var fakeList = new List<IAitoeRedCell>();
    var mockingKernel = new MoqMockingKernel();
    
    var camProcRepositoryMock = mockingKernel.GetMock<ICamProcRepository>();
    
    camProcRepositoryMock.Setup(e => e.GetAllAitoeRedCells()).Returns(fakeList);
    
    camProcRepositoryMock.Setup(e => e.CreateAitoeRedCell()).Returns(() => Mock.Of<IAitoeRedCell>());
