    Foo GetObject(TestName testNames, string id, string name)
    {
        return testNames.TestItems
            .Where(ex => ex.TestNamesId == id && ex.TestItemName == name)
            .Select(r => new
                {
                    r.TestItemId,
                    r.TestItemName,
                    r.TestItemDirectory
                }).FirstOrDefault();
    }
