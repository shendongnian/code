    class ExampleDTO
    {
        public int Id;
        public enum Type;
        public DateTime creationTime;
        public ISet<string> StringThings;
        [IgnoreMap]
        public HashSet<string> StringThingsHash
        {
            get
            {
                return StringThings;
            }
        }
        public ISet<int> IntThings;
        [IgnoreMap]
        public HashSet<int> IntThingsHash
        {
            get
            {
                return IntThings;
            }
        }
        public ISet<double> DoubleThings;
        [IgnoreMap]
        public HashSet<double> DoubleThingsHash
        {
            get
            {
                return DoubleThings;
            }
        }
