    public int a {
        set {
            if (value <= b)
                _a = value;
            if (value > b)
                _a = b;
        }
    }
