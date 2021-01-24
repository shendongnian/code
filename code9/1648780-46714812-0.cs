    public async void ScanCode()
    {
        _codes = new ObservableCollection<string>();
         OnPropertyChanged(nameof(Codes));
    ...
 
