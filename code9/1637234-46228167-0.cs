    public ICommand ShowNumpadCommand { get; }
    public DoubleParameterViewModel(Parameter<double> parameter)
    {
        this.parameter = parameter;
        ShowNumpadCommand = new RelayCommand<string>(ShowNumpad);
    }
    private void ShowNumpad(string parameterName)
    {
        /* ... */
    }
