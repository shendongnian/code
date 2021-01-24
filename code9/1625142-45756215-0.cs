    public ObservableCollection<string> Items { get; } = new ObservableCollection<string>() { "a", "b", "c" };
    private string _text;
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
            //add the missing value...
            if (!Items.Contains(_text))
                Items.Add(_text);
        }
    }
    private string _selectedItem;
    public string SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
