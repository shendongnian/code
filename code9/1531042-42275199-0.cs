    [TestClass]
    public class AccountInfoUnitTests {
        [TestMethod]
        public void AccountInfo_RefreshAmount_Given_Id_Should_Return_Expected_Amount() {
            //Arrange
            //creating expected values for test
            var expectedId = 1;
            var expectedAmount = 100D;
            //mock implementation of service using Moq
            var serviceMock = new Mock<IService>();
            //Setup expected behavior
            serviceMock
                .Setup(m => m.GetAmount(expectedId))
                .Returns(expectedAmount)
                .Verifiable();
            //the system under test
            var sut = new AccountInfo(expectedId, serviceMock.Object);
            
            //Act
            //exercise method under test
            sut.RefreshAmount();
            //Assert
            //verify that expectations have been met
            serviceMock.Verify();
            Assert.AreEqual(expectedAmount, sut.Amount);
        }
        //Samples class and interface to explain example
        public class AccountInfo {
            private readonly int _Id;
            private readonly IService _service;
            public AccountInfo(int Id, IService service) {
                _Id = Id;
                _service = service;
            }
            public double Amount { get; private set; }
            public void RefreshAmount() {
                Amount = _service.GetAmount(_Id);
            }
        }
        public interface IService {
            double GetAmount(int accountId);
        }
    }
