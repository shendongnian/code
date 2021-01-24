    [TestClass]
    public class UnitTestSettings {
        [TestMethod]
        public void TestMethod1() {
            //Arrange
            var expected = "Place expected connection string here"
            //Act
            var actual = Settings.Settings.ConnectionString();
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }
    }
