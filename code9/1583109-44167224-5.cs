    [DataTestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(2, 2, 4)]
    [DataRow(3, 2, 6)]
    [DataRow(5, 2, 7)]
    public void RowTest(int a, int b, int result)
    {
        Assert.AreEqual(result, a + b);
    }
