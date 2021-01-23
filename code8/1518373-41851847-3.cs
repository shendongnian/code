    [TestFixture]
    public class UnitTest1 {
        [Test]
        public void ValidateNameNodeStatus() {
            //Arrange
            var expected = "active";
            var validation = Substitute.For<IClusterMonitoring>();
            validation.GetNameNodeStatus("", new Credential()).Returns(expected);
            var controller = new HomeController(validation);
            //Act
            var actual = controllers.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Model); 
        }
    }
