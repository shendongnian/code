        public class foo {
        public int X { get; set; }
        public string Y { get { return X.ToString(); } }
        public double Z { get; private set; }
        private foo(int x) { X = x; }
        public foo(int x, string y, double z = 1.0): this(x) {
            Z = z;
            }
        }
