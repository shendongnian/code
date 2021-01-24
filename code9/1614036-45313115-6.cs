    [TestClass]
    public class DataClassParserTest {
        [TestMethod]
        public void DataClassParser_Should_Return_DataClass() {
            //Arrange
            string mockData = "..."; //TODO: Populate mockData
            var sut = new DefaultDataClassParser();
            //Act
            var actual = sut.Parse(mockData);
            //Assert
            //TODO: assert that the actual result satisfies expectations
        }        
    }
