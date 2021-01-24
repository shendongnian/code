    [TestClass]
    public class AcombaProductsRepositoryTests {
        private readonly Mock<IProduct022> nativeRepositoryMock;
        private readonly AcombaProductsRepository sut;
        public AcombaProductsRepositoryTests() {
            nativeRepositoryMock = new Mock<IProduct022>();
            sut = new AcombaProductsRepository(nativeRepositoryMock.Object);
        }
        [TestMethod]
        public void _Create_Should_Reserve_A_Card_Number() {
            //Arrange
            var toCreate = new MyProduct();
            nativeRepositoryMock.Setup(r => r.ReserveCardNumber()).Verifiable();
            //Act
            sut.Create(toCreate);
            //Asert
            nativeRepositoryMock.Verify(r => r.ReserveCardNumber());
        }
    }
