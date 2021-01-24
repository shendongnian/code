    public MyViewModel()
    {
        MyObsCollectionProp = new ObservableCollection<YourModel>();
        MyObsCollectionProp += MyObsCollectionProp_Changed;
    }
    void MyObsCollectionProp_Changed(object sender, NotifyCollectionChangedEventArgs e)
    {
        // Handle here
        IsButtonEnable = MyObsCollectionProp.All(record=>record.IsValid)
    }
