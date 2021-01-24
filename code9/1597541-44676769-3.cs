    public ParentViewModel()
    {
        ChildViewModel = new ChildViewModel(params);
        //  Handle child's PropertyChanged event
        ChildViewModel.PropertyChanged += ChildViewModel_PropertyChanged;
    }
    private void ChildViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var child = (ChildViewModel)sender;
        if (e.PropertyName == nameof(ChildViewModel.SelectedNumber))
        {
            //  Do stuff
        }
    }
