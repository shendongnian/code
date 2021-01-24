    var viewModel = (ConfigureViewModel)DataContext;
    if (viewModel.LoadModuleCommand.CanExecute(null))
    {
        viewModel.LoadModuleCommand.Execute(null);
    }
