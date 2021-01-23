    [TestClass]
    public class MyControllerTests {
        [TestMethod]
        public void PostAction_Should_Receive_Json_Data() {
            //Arrange
 
            var model = new MyModel { 
              Key = "Value"
            };
            var sut = new MyController();
            //Act
            var result = sut.PostAction(model);
            //Assert
            //...assertions here.
        }
    }
