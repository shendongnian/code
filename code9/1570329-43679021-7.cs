    private RelayCommand _changeTrucksCommand;
    public RelayCommand ChangeTrucksCommand
    {
        get
        {
            if (_changeTrucksCommand == null)
                _changeTrucksCommand = new RelayCommand(async o => await ChangeTrucksAsync());
                return _changeTrucksCommand;
            }
        }
     }
