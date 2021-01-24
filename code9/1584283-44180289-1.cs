    IEnumerable<string> GetAllNames(TestA root) {
        return GetAllNames(new[] { root });
    }
    IEnumerable<string> GetAllNames(IEnumerable<TestA> tests) {
        var queue = new Queue<TestA>(tests);
        while (queue.Count > 0) {
            var current = queue.Dequeue();
            yield return current.Name;
            if (current.TestCollection != null) {
                foreach (var child in current.TestCollection) {
                    queue.Enqueue(child);
                }
            }
        }
    }
