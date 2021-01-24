    private Nested bar = new Nested(this); // Invalid
    public Nested Bar
    {
        get { return bar; }
    }
