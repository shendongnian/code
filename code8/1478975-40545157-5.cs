    public MyClassViewModel()
    {
        PropertyChanging += OnPropertyChanging;
        PropertyChanged += OnPropertyChanged;
    }
    private void OnPropertyChanging(object sender, PropertyChangingEventArgs e)
    {
        if (e.PropertyName != nameof(MyClassViewModel.myClassBase))
            return; //or do something with the other properties
        if (myClassBase == null)
            return;
        myClassBase.PropertyChanged -= OnMyBaseClassPropertyChanged;
    }
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(MyClassViewModel.myClassBase))
            return; //or do something with the other properties
        if (myClassBase == null)
            return;
        myClassBase.PropertyChanged += OnMyBaseClassPropertyChanged;
    }
    private void OnMyBaseClassPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        RaisePropertyChanged(e.PropertyName);
    }
