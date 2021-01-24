    public static IEnumerable<object[]> Data()
    {
        // data goes here
    }
    [Theory]
    [MemberData(nameof(Data))]
    public void TestData(string expected, string actual)
    {
        // assert goes here
    }
