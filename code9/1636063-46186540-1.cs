    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test_ISitecoreContextInsertion() {
            //Arrange
            var model = new Home_Control() {
                //...populate as needed
            }
            var iSitecoreContext = new Mock<Glass.Mapper.Sc.ISitecoreContext>();
            //Setup the method to return a model when called.
            iSitecoreContext.Setup(_ => _.GetCurrentItem<Home_Control>()).Returns(model);
            var controllerUnderTest = new HomeBottomContentController(iSitecoreContext.Object);
            //Act
            var result = controllerUnderTest.Index() as ViewResult;
   
            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            //...other assertions.
        }
    }
