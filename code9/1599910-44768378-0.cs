    public int a {
        set {
            if (value <= b)
                a = value;
            if (value > b)
                a = b;
        }
    }
