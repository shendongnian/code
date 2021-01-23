    [TestFixture]
    public class BLLTest {
        private MyBLL _myBLL;
    
        public BLLTest() {
            //Arrange        
            var dalMock = new Mock<IMyDAL>();
            dalMock.Setup(x => x.DoDALStuff()).Returns(true);//setup expected behavior
            //...setup other expected behavior of dependencies
            //create the target of unit test (class under test)
            _myBLL = new MyBLL(dalMock.Object); //manually injecting dependency
        }
    
        [Test]
        public void TestTheBLL() {
            //Act
            var result = _myBLL.DoBLLStuff();
            //Assert
            Assert.IsTrue(result);
        }
    }
