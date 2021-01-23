    private int _enumeratorPosition = -1;
    public void Reset() { _enumeratorPosition = -1; }
    public bool MoveNext()
    {                
        _enumeratorPosition++;
        return (_enumeratorPosition < MyListContainer.Count);                
    }
    public object Current
    {
        get { return MyListContainer[_enumeratorPosition]; }
    }
