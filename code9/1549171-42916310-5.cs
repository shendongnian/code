    class Foo
    {
        public readonly int shoeSize; // readonly field
        public int ShoeSize { get { .. } } // readonly property
        public int ToeSize { get; } = 5; // readonly property with initializer
        // ..etc
    }
