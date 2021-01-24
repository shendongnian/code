    class DataItem : INotifyPropertyChanged
    {
        public string Item1 { get; set; }
        public Dictionary<string, string> Item2 { get; set; }
        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    ...
    foreach (DataColumn dc in _loadedData.Columns)
    {
        ListBox.Items.Add(new DataItem() { Item1 = dc.ColumnName, Item2 = cbxOptions });
    }
