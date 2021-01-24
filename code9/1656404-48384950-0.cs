    public void UpdateSource(ObservableCollection<TestModel> newSource)
    {
        TestSource.Clear();
        TestSource.AddRange(newSource);
        OnPropertyChanged("TestSource");
    }
