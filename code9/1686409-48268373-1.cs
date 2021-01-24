    [TestClass]
    public class MyControllerTest {
        [TestMethod]
        public void ShouldNotCallAnyMethodsWhenConfigurationReturnsNull() {
            //Arrange
            var mockConfigurationReader = new Mock<IConfigurationReader>();
            mockConfigurationReader
                .Setup(cr => cr.GetEnabledConfigurations())
                .Returns((IEnumerable<Configuration>)null);
            var mockController = new Mock<MyController>(mockConfigurationReader.Object) {
                CallBase = true
            };
            //Act
            mockController.Object.EntranceMethod();
            //Assert
            // todo: verify no additional methods are called
            mockController.Verify(_ => _.WorkerMethod1(), Times.Never());
            mockController.Verify(_ => _.WorkerMethod2(), Times.Never());
            mockController.Verify(_ => _.WorkerMethod3(), Times.Never());
        }
    }
