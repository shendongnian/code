    [TestClass]
    public class RateServiceUnitTests {
        [TestMethod]
        public void Given_ValidId_GetById_Should_Return_Dto() {
            //Arrange
            var validId = 1;
            var fakes = new List<Rates>() {
                new Rates { RateId = validId }
            };
            var mock = new Mock<IDbContext>();
            //Assuming IDbContext.Rates.GetAll() returns an IEnumerable<Rates>
            mock.Setup(m => m.Rates.GetAll()).Returns(fakes);
            var sut = new RateService(mock.Object);
            //Act
            var result = sut.GetById(validId);
            //Assert
            Assert.IsNotNull(result);
        }
    }
