    Dictionary<TestType,List<TestCase>> dataAsDictionary = data
        .GroupBy(x => x.TestType)
        .ToDictionary(
            k => k.Key
        ,   v => v.Select( f=> new TestCase() { Id = f.Id }).ToList()
        ); //                                               ^^^^^^^^^
