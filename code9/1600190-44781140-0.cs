    public IEnumerable<bar_one> bar_ones
    {
        get
        {
            return this.bars.OfType<bar_one>();
        }
    }
