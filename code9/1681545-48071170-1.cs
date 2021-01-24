    [TestClass]
    public class MyClass1_Test {
        [TestMethod]
        public void MyClass1_Should_Generate_Output() {
            //Arrange
            var expected = 0;
            var mock = new Mock<MyClass1>() {
                CallBase = true //<-- let mock call base members
            };
            mock.Setup(_ => _.GetValue()).Returns(expected); // <-- mocked behavior
            var sut = mock.Object; //<-- subject under test.
            //Act
            var actual = sut.GenerateOutPut();
            //Assert
            actual.Should().Be(expected + 1);
        }
    }
