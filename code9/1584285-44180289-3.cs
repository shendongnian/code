     IEnumerable<string> GetAllNamesStack(IEnumerable<TestA> tests) {
        var stack = new Stack<TestA>(tests.Reverse());
        while (stack.Count > 0) {
            var current = stack.Pop();
            yield return current.Name;
            if (current.TestCollection != null) {
                foreach (var child in current.TestCollection) {
                    stack.Push(child);
                }
            }
        }
    }
