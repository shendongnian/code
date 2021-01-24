    [TestClass]
    public class ATest {
        [TestMethod]
        public void MethodUnderTest_Should_Return_DataClassList() {
            //Arrange
            List<string> mockData = new List<string>();
            //TODO: Populate mockData
            var mockB = new Mock<ISecondClass>();
            mockB.Setup(_ => _.GenerateFile()).Returns(mockData);
            var sut = new A(mockB.Object, new DefaultDataClassParser());
            //Act
            var actual = sut.MethodUnderTest();
            //Assert
            //TODO: assert that the actual result satisfies expectations
        }        
    }
