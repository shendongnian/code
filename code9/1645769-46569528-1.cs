    public ObservableCollection<myItem> source { get; set; }
    public void AddValues(int index)
    {
        source[index].col8 = source[index].col3 + source[index].column5;
    }
