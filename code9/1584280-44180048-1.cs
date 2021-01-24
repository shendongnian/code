    IEnumerable<string> GetAllNames(TestA root) {
        return GetNames(new[] {root}); // Forward to a method taking IEnumerable<T>
    }
    IEnumerable<string> GetAllNames(IEnumerable<TestA> tests) {
        return tests
            .Select(t => t.Name) // Names at this level
            .Concat(tests.SelectMany(t => GetAllNames(t.TestCollection))); // Names of children
    }
