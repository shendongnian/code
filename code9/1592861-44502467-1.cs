    public void AddColumn()
    {
        this.Table.Columns.Add("ColumnTest");
        OnPropertyChanged(nameof(Table));
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName) => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
