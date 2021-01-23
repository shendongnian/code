    [TestFixture]
    public class UnitTest1 {
        [Test]
        public void ValidateNameNodeStatus() {
            //Arrange
            var validation = Substitute.For<IClusterMonitoring>();
            validation.GetNameNodeStatus("", new Credential()).Returns("active");
            var controller = new HomeController(validation);
            //Act
            var result controllers.Index();
            //Assert
            //...
        }
    }
