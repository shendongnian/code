    List<Ideas> _ideas;
    public List<Ideas> Ideas
    {
        get { return _ideas; }
        set
        {
            if(value == _ideas) return;
            _ideas = value;
            OnPropertyChanged();
        }
    }
