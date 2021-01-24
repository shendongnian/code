    private static IEnumerable<object[]> CombinationData()
    {
        var testcase = new List<List<string>>
        {
            new List<string>{ "a", "b", "c" }, 
            new List<string>{ "x", "y", "z" }
        };  
        yield return new object[] { testcase };
    }
    
