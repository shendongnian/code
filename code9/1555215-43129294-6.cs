    private BaseCommand<object> _selectFileCommand;
    public ICommand SelectFileCommand
    {
        get
        {
            if (_selectFileCommand == null)
            {
                _selectFileCommand = new BaseCommand<object>((commandParam) => OpenSelectedFile(commandParam),
                                                             (commandParam) => CanOpenSelectedFile(commandParam));
            }
            return _selectFileCommand;
        }
    }
    public void OpenSelectedFile(object commandParam = null)
    {
        Debug.WriteLine("CatalogViewModel.OpenSelectedFile was called.");
        Debug.WriteLine("SelectedValue = " + this.SelectedValue);
    }
    public bool CanOpenSelectedFile(object commandParam = null)
    {
        return true;
    }
