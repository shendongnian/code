    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            var program = new Program();
            
            // Act
            program.MyProdMethod();
            // Assert
            Assert.AreEqual("Yes I set it", program.Status);
        }
    }
