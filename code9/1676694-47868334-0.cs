    class Tiger : ValueType<Tiger> {
        public string name; public Tiger mother;
        public override bool Equals(object obj)
        {
            return ((ValueType<Tiger>) obj).Equals(this);
        }
    }
