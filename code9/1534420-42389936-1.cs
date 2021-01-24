    var testList = new List<ITestKeyword>();
    
    _mockTestHelper
        .Setup(s => s.AddTests(It.IsAny<TestEntity>()))
        .Returns(testList);
