    var testDataMock = new Mock<TestData>(); // Moq as example
    testDataMock.Setup(t => t.TestResult()).Returns("some string");
    ClassData.TestData = testDataMock.Object; 
    var result = ClassData.GetData();
    
    //Assertions
