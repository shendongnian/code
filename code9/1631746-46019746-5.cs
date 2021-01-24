    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethodC()
        {
            //Arrange
            var expected = 20;
            var c = new D();
    
            //Act
    		int actual = c.methodC();
    
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
