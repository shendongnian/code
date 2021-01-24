    [TestClass]
    public class AccountObjUnitTests {
        [TestMethod]
        public void AccountObj_Given_Id_RefreshAmount_Should_Return_Expected_Amount() {
            //Arrange
            //creating expected values for test
            var expectedId = 1;
            var expectedAmount = 100D;
            //mock implementation of service using Moq
            var serviceMock = new Mock<IService>();
            //Setup expected behavior
            serviceMock
                .Setup(m => m.GetAmount(expectedId))//the expected method called with provided Id
                .Returns(expectedAmount)//If called as expected what result to return
                .Verifiable();//expected service behavior can be verified
            //the system under test
            var sut = new AccountObj(expectedId, serviceMock.Object);
            
            //Act
            //exercise method under test
            sut.RefreshAmount();
            //Assert
            //verify that expectations have been met
            serviceMock.Verify(); //verify that mocked service behaved as expected
            Assert.AreEqual(expectedAmount, sut.Amount);
        }
        //Samples class and interface to explain example
        public class AccountObj {
            private readonly int _Id;
            private readonly IService _service;
            public AccountObj(int Id, IService service) {
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
