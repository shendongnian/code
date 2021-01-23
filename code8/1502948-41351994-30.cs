    IEnumerable<FileObject> FoldImagesInPath(string folderPath, int firstAssignedID) =>
        Directory.EnumerateFiles(folderPath)
                 .Fold(
                      Tuple.Create(firstAssignedID, Enumerable.Empty<FileObject>()),
                      (state, path) => Tuple.Create(state.Item1 + 1, FileObject.New(state.Item1, path).Cons(state.Item2)))
                 .Item2;
