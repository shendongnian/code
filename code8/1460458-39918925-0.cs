    public enum TestEnum : byte {
      One = 1,
      Two = 2
    }
 
    [TestMethod()]
    Public void InListTest()
    {
        Assert.IsTrue(ValidationUI.InList(1, typeof(TestEnum));
        Assert.IsFalse(ValidationUI.InList(100, typeof(TestEnum));
    }
