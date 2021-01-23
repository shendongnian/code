    <ListBox ItemsSource="{Binding Numbers}" SelectedItem="{Binding SelectedNumber}" />
    <ListBox ItemsSource="{Binding SubNumbers}" />
----------
    private object _selectedNumber;
    public object SelectedNumber
    {
        get { return _selectedNumber; }
        set
        {
            _selectedNumber = value;
            NotifyPropertyChanged();
            //set items
            SubNumbers = new List<string> { "3A", "3B", "..." };
            NotifyPropertyChanged("SubNumbers");
        }
    }
