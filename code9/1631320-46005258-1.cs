    private string _helpText = "Testing";
    public string HelpText
    {
        get
        {
            return _helpText;
        }
        set
        {
            Set(() => HelpText, ref _helpText, value);
        }
    }
    
    private ICommand _mouseEnter;
    public ICommand MouseEnter
    {
        get
        {
            return _mouseEnter;
        }
        set
        {
            Set(() => MouseEnter, ref _mouseEnter, value);
        }
    }
    
    private ICommand _mouseLeave;
    public ICommand MouseLeave
    {
        get
        {
            return _mouseLeave;
        }
        set
        {
            Set(() => MouseLeave, ref _mouseLeave, value);
        }
    }
