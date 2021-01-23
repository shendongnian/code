    INotifyPropertyChanged viewModel = (INotifyPropertyChanged)this.DataContext; 
    viewModel.PropertyChanged += (sender, args) => {
        if (!args.PropertyName.Equals("foo"))
            return;
        // execute code here.
    };
