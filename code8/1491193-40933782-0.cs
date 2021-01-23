    public event IndexChangedEventHandler IndexChanged;
    public delegate void IndexChangedEventHandler(int newValue);
    protected virtual OnIndexChanged(int newValue)
    {
        if (IndexChanged != null)
            IndexChanged(newValue);
    }
