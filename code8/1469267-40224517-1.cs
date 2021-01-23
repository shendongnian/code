    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void MyTestMethod() {
            //Arrange
            var calcMock = new Mock<ICalc>();
            calcMock.Setup(m => m.GetSum(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int a, int b) => a + b)
                .Verifiable();
            var factoryMock = new Mock<ISumFactory>();
            factoryMock.Setup(m => m.GetSumObject(1)).Returns(calcMock.Object)
            .Verifiable();
            var sut = new SalaryManager(factoryMock.Object);
            //Act
            var result = sut.DoCalculation(1, 1);
            //Assert
            //...
            factoryMock.Verify();
            calcMock.Verify();
        }
    }
