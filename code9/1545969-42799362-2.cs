    [TestClass]
    public class DataAccessLayerUnitTest {
        [TestMethod]
        public void TestInsert() {
            //Arrange
            var commandMock = new Mock<IDbCommand>();
            commandMock
                .Setup(m => m.ExecuteNonQuery())
                .Verifiable();
                
            var connectionMock = new Mock<IDbConnection>();
            connectionMock
                .Setup(m => m.CreateCommand())
                .Returns(commandMock.Object);
                
            var connectionFactoryMock = new Mock<IDbConnectionFactory>();
            connectionFactoryMock
                .Setup(m => m.CreateConnection())
                .Returns(connectionMock.Object);
    
            var sut = new MyDataAccessClass(connectionFactoryMock.Object);
            var firstName = "John";
            var lastName = "Doe";
    
            //Act
            sut.Insert(firstName, lastName);
    
            //Assert
            commandMock.Verify();
        }
    }
