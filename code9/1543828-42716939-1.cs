    [Theory, MemberData(nameof(Guids))]
    public void thinkofsomesmartname(bool expectedResult, string text)
    {
        Assert.Equals(expectedResult, text.IsGuid());
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
