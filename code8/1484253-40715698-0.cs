    public ICommand ShowViewCommand { get; set; }
    public Foo() // Replace with your class name
    {
        ShowViewCommand = v => new DelegateCommand<string>(v =>
        {
            var viewModel = new EditFormViewModel;
            var ucType = Assembly.GetExecutingAssembly().GetType(v);
            App.SetWindowView(viewModel, ucType);
        });
    }
