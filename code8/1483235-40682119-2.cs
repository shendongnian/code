    INotifyPropertyChanged previous;
    // constructor
    public SomeCodeBehindClass()
    {
        previous = (INotifyPropertyChanged)this.DataContext;
        DataContextChanged += (sender, args) => SubscribeToFooChanges((INotifyPropertyChanged)args.NewValue);
        SubscribeToFooChanges(previous);
    }
    
    // subscriber
    private void SubscribeToFooChanges(INotifyPropertyChanged viewModel)
    {
        previous.PropertyChanged -= FooChanged;
        previous = viewModel;
        viewModel.PropertyChanged += FooChanged;
    }
    // event handler
    private void FooChanged (object sender, PropertyChangedEventArgs args)
    {
        if (!args.PropertyName.Equals("foo"))
            return;
        // execute code here.
    }
