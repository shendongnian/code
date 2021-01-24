    Foo GetObject(TestName testNames, Func<TypeOfEx, bool> predicate)
    {
        return testNames.TestItems
            .Where(predicate)
            .Select(r => new
                {
                    r.TestItemId,
                    r.TestItemName,
                    r.TestItemDirectory
                }).FirstOrDefault();
    }
