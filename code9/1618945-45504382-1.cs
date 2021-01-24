    public RelayCommand SelectExchangeProductCommand { get; private set; }
    public ViewModel()
    {
        SelectExchangeProductCommand = new RelayCommand(SelectExchangeProductExecute, SelectExchangeProductCanExecute);
    }
