    private ICommand _showFactorDetailCommand;
    public ICommand ShowFactorDetailCommand
    {
        get
        {
            if (_showFactorDetailCommand == null)
            {
                _showFactorDetailCommand = new RelayCommand(p => true, p => show());
            }
            return _showFactorDetailCommand;
        }
    }
    private void show()
    {
        CurrentViewModel = ViewModels.Single(s => s.Title == "Factor");
    }
