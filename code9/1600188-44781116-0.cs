    public List<bar_one> bar_ones
    {
        get
        {
            return (this.bars.Where(x => x.barType == barType.one)).ToList().Cast<bar_one>().ToList();
        }
    }
