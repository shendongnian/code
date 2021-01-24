    // Arrange
    var fixture = New Fixture();
    var input = fixture.Create<int>(); // Will generate some integer value
    var expected = fixture.Create<string>();
    var dependencyOne = fixture.Create<IPromiseOne>(); // Don't care about in this test
    var dependencyTwo = Substitute.For<IPromiseTwo>(); // Dependency required in the test
    // return "expected" only when "input" given
    dependencyTwo.SomeFunction(input).Returns(expected); 
    var classUnderTest = new ClassUnderTest(dependencyOne, dependencyOne);
    // Act
    var actual = classUnderTest.Convert(input);
    // Assert
    actual.Should().Be(expected);
