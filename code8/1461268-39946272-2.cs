    BinaryNode<T> _root;
    public BinaryNode<T> Root
    {
        get { return _root; }
        set { _root = value; }
    }
            
    public T Insert(T val)
    {
        return Insert(ref _root, val);
    }
