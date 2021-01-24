    [TestClass]
    public class BarTest
    {
        [TestMethod]
        public async Task Test_Foo()
        {
            // Arrange
            var bar = new Bar();
            // Act
            var result = await bar.Foo();
            // Assert
            Assert.AreEqual("123", result);
        }
    }
