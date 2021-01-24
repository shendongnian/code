    IEnumerable<string> GetNames(List<TestA> testAList)
    {
        return testAList.Select(x => x.Name)
                        .Concat(testAList.SelectMany(x => GetNames(x.TestCollection)));
    }
    
    var names = GetNames(testAList);
