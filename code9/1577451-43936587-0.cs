    public void Populate()
    {
        _myList = new ObservableCollection<Month>(DataBase.GetMonths(2017));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyList)));
    }
