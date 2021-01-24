    public ICommand CompositeCommand { get; } = new RelayCommand<object>((arg) =>
    {
        DeleteCustom.Execute(null);
        CancelCommand.Execute(null);
    });
