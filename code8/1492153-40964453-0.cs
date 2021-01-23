    public class Animal
    {
        public string A { get; } // related to instance
        public string B { get; }
        public string C { get; }
        public string X { get; }
        public string Y { get; }
        public string Z          // gets or sets static variable which will affect all animals.
        {
            get { return _z; }
            set { _z = value; }
        }
        private static string _z;
    }
