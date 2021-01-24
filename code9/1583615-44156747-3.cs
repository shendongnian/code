    [TestMethod]
    public void TestMoq() {
        // Arrange
        var mockA = new Mock<IA>();
        mockA.Setup(a => a.FooA());
    
        // Act
        B b = new B(mockA.Object);
        b.FooB();
    
        // Assert
        mockA.VerifyAll();
    }
