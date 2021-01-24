    public IList<View> Children
    {
        get { return _children; }
    }
    // and the constructor
    public MyControl() {
        _children = new List<View>();
    }
