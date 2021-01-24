    private bool _switch = true;
    // Bind switch.IsChecked to this property:
    public bool Switch 
    {
        get => _switch; 
        set => Set( nameof(Switch), ref _switch, value); 
    }
    
    private RelayCommand _btnCmd;
    public RelayCommand ButtonCommand => _btnCmd ?? (_btnCmd = 
                            new RelayCommand(ButtonCommand_Execute, ButtonCommand_CanExecute));
    // What will happen on Button Click    
    private void ButtonCommand_Execute(){ /* ...*/ }
    // Sets the Enabled Property of the Button according to the state of the Switch property.
    private bool ButtonCommand_CanExecute() { return Switch; }
