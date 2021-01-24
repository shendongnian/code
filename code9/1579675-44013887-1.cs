    [TestClass]
    public class UnitTest1 {
        Mock<ISayGoodMorning> GoodMorningMock;
        [TestInitialize]
        public void init() {
            //Arrange
            GoodMorningMock = new Mock<ISayGoodMorning>();
            GoodMorningMock.Setup(_ => _.GoodMorning()).Returns(Test());
        }
        [TestMethod]
        public void TestMethod1() {
            //Arrange cont'd
            var g = new ClassLibrary2.Greeting(GoodMorningMock.Object);
            var expected = "Hola";
            //Act
            var actual = g.SayGreeting();
            //Assert
            GoodMorningMock.Verify(_ => _.GoodMorning(), Times.Once());
            Assert.AreEqual(expected, actual);  
        }
        public string Test() {
            return "Hola";
        }
    }
