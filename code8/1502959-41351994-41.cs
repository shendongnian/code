    public static class FileObjectsState
    {
        // Creates a tuple with state ID of zero (Item1) and an empty FileObject enumerable (Item2)
        public static readonly Tuple<int, IEnumerable<FileObject>> Zero = 
            Tuple.Create(0, Enumerable.Empty<FileObject>());
        // Returns a new tuple with the ID (Item1) set to the supplied argument
        public static Tuple<int, IEnumerable<FileObject>> SetId(this Tuple<int, IEnumerable<FileObject>> self, int id) =>
            Tuple.Create(id, self.Item2);
        // Returns the important part of the result, the enumerable of FileObjects
        public static IEnumerable<FileObject> Result(this Tuple<int, IEnumerable<FileObject>> self) =>
            self.Item2;
        // Adds a new path to the aggregate state and increases the ID by one.
        public static Tuple<int, IEnumerable<FileObject>> Add(this Tuple<int, IEnumerable<FileObject>> self, string path) =>
            Tuple.Create(self.Item1 + 1, FileObject.New(self.Item1, path).Cons(self.Item2));
    }
