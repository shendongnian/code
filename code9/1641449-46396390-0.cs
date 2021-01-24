    [Fact]
    public void Work_is_done_in_sequence() {
        //Arrange
        var mock = new Mock<ITarget>();
        var refClass = new RefClass(mock.Object);
        var testClass = new TestClass(mock.Object);
        //Act
        refClass.Work();
        testClass.Work();
        //Assert
        var expected_A_Val = "some_value";
        mock.Verify(_ => _.A(expected_A_Val), Times.Exactly(2));
   
        var expected_B_Val = 3;
        mock.Verify(_ => _.B(expected_B_Val), Times.Exactly(2));        
    }
