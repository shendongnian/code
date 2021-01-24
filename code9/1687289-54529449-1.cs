    [TestMethod]
    public void TestCoolClass()
    {
        var expected = new CoolClass("42", 42);
        var arr = new CoolClass[]
        {
            new CoolClass("A", 10),
            new CoolClass("B", 101),
            new CoolClass("C", 11)
        };
        // Arrange
        var sut = Mock.Create<Foo>();
        Mock.Arrange(sut, s => s.GetSpecialItem_New(arr)).Returns(LocalRef.WithValue(expected).Handle).OccursOnce();
        // Act
        ref CoolClass actual = ref sut.GetSpecialItem_New(arr);
        // Assert
        Assert.AreEqual(expected, actual);
    }
