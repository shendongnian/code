    private ICommand _showCommand;
    public ICommand ShowCommand
    {
        get
        {
            if (_showCommand == null)
            {
                _showCommand = new RelayCommand(p => true, p => show(p));
            }
            return _showCommand;
        }
    }
    private void show(p)
    {
        var vm = (string)p;
        CurrentViewModel = ViewModels.Single(s => s.Title == vm);
    }
