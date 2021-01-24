    public int a {
        internal get {
            return _a;
        }
        set {
            if (value <= b)
                _a = value;
            if (value > b)
                _a = b;
        }
    }
