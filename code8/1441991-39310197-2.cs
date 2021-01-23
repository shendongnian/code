    var mockingKernel = new MoqMockingKernel();
    
    var camProcRepositoryMock = mockingKernel.GetMock<ICamProcRepository>();
 
    var fakeList = new List<IAitoeRedCell>();
    //You can either leave the list empty or populate it with mocks.
    //for(int i = 0; i < 5; i++) {
    //    fakeList.Add(Mock.Of<IAitoeRedCell>());
    //}
   
    camProcRepositoryMock.Setup(e => e.GetAllAitoeRedCells()).Returns(fakeList);
    
    camProcRepositoryMock.Setup(e => e.CreateAitoeRedCell()).Returns(() => Mock.Of<IAitoeRedCell>());
