    public string FilterString
    {
        get { return _filterString; }
        set
        {
            _filterString = value;
            NotifyPropertyChanged(nameof(FilterString));
            _matchesView.Refresh();
        }
    }
