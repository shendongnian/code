    class Set : IEnumerable<int>
    {
        private readonly List<int> wrappedCollection = new List<int>();
        
        public void Add(int value)
        {
            wrappedCollection.Add(value);
        }
        ...
    }
