        #if USE_FLOAT
    public struct SingleOrDouble : IComparable
        , IComparable<Single>, IEquatable<Single> {
        public Single Value;
        private SingleOrDouble(float f) {
            Value = f;
        }
        public static implicit operator float(SingleOrDouble s) {
            return s.Value;
        }
        public static implicit operator SingleOrDouble(float f) {
            return new SingleOrDouble(f);
        }
        public int CompareTo(float other) {
            return Value.CompareTo(other);
        }
        public bool Equals(float other) {
            return Value.Equals(other);
        }
        public static bool IsInfinity(float f) {
            return Single.IsInfinity(f);
        }
             
       
        #else
    public struct SingleOrDouble : IComparable
       , IComparable<Double>, IEquatable<Double> {
        public Double Value { get; set; }
        private SingleOrDouble(double d) {
            Value = d;
        }
        public static implicit operator double(SingleOrDouble d) {
            return d.Value;
        }
        public static implicit operator SingleOrDouble(double d) {
            return new SingleOrDouble(d);
        }
        public int CompareTo(double other) {
            return Value.CompareTo(other);
        }
        public bool Equals(double other) {
            return Value.Equals(other);
        }
        
        #endif
        public int CompareTo(object obj) {
            return Value.CompareTo(obj);
        }
        public TypeCode GetTypeCode() {
            return Value.GetTypeCode();
        }
        public static bool IsInfinity(double d) {
            return Double.IsInfinity(d);
        }
    }
