    [Theory, MemberData(nameof(Guids))]
    public void thinkofsomesmartname(bool expectedResult, string text)
    {
        bool result = text.IsGuid();
        Assert.Equal(expectedResult, result);
    }
    public static IEnumerable<object[]> Guids
    {
        get
        {
            yield return new object[]{ false, "" };
            yield return new object[]{ false, " " };
            yield return new object[]{ true, Guid.NewGuid().ToString() };
        }
    }
