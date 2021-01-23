    private BaseViewModel _viewModel;
    public BaseViewModel ViewModel
    {
      get { return _viewModel; }
      set
      {
        if(_viewModel != value) 
        {
          _viewModel = value;
          OnPropertyChanged("ViewModel");
        }
      }
    }
