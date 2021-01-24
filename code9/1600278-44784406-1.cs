    [TestMethod]
    public void TestMoverExtension()
    {
    
        var testValues = new int[] { 0, 1, 2, 3, 4, 5 };
    
        var result = testValues.MoveValueToFront(3);
    
    
        CollectionAssert.AreEqual(new int[] { 3, 0, 1, 2, 4, 5 }, result);
    }
