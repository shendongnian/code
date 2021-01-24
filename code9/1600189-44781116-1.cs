    IEnumerable<bar_one> bar_ones
    {
        get
        {
            return this.bars.Where(x => x.barType == barType.one).Cast<bar_one>();
        }
    }
