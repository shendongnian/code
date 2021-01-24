    public static object[] SumTest =
    {
        new object[] {6, true, new int[] {1, 5, 7, 12, 20}},
        new object[] {37, true, new int[] {1, 5, 7, 12, 20}},
        new object[] {9, false, new int[] {1, 5, 7, 12, 20}}
    };
    
    [TestCaseSource("SumTest")]
    public void Test(int value, bool expectedResult, int[] values)
    {
        Assert.AreEqual(expectedResult, CanBeSummed(value, values));
    }
