    [TestMethod, TestCategory("ImportantTest")]
    public void MethodToTest_Circumstances_ExpectedResult() {
        // Arrange
        var variable1 = new Type1() { Value = "hello" };
        var variable2 = new Type2() { Name = "Bob" };
    
        // Act
        Action act = () => MethodToTest(variable1, variable2);       
    
        // Assert
        // This method should have thrown an exception
        act.ShouldThrow<DataException>()
           .WithMessage(Constants.DataMessageForMethod);
        // test that variable1 was changed by the method
        variable1.Should().NotBeNull();
        variable1.Value.Should().Be("Hello!");
        // test that variable2 is unchanged because the method threw an exception before changing it
        variable2.Should().NotBeNull();
        variable2.Name.Should().Be("Bob");
    }
