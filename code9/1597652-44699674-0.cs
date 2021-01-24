    private RelayCommand checkAllCommand;
    public ICommand CheckAllCommand
    {
        get
        {
            return checkAllCommand ??
                (checkAllCommand = new RelayCommand(param => this.SelectUnselectAll(Convert.ToBoolean(param))));
        }
    }
