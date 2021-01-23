    public IEnumerable<string> EnumerateFiles(string startingDirectoryPath) {
        var directoryEnumerables = new Queue<IEnumerable<string>>();
        directoryEnumerables.Enqueue(new string[] { startingDirectoryPath });
        while (directoryEnumerables.Any()) {
            var currentDirectoryEnumerable = directoryEnumerables.Dequeue();
            foreach (var directory in currentDirectoryEnumerable) {
                foreach (var filePath in fileEnumeratorFunc(directory)) {
                    yield return filePath;
                }
                directoryEnumerables.Enqueue(Directory.EnumerateDirectories(directory));
            }                
        }
    }
