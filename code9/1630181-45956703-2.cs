    //Arrange
    var t = new TestForm();
    
    //Act
    Program.Main(t);
    t.ExecuteSomeTest();
    //Assert
    Assert.AreEqual(t.ResultCode, 0, "Test failed.");
 
