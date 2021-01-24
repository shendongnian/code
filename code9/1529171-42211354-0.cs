    public DelegateCommand<KeyEventArgs> KeyUpEventCommand { get; private set; }
    private string strAlphabet;
    public string Alphabets
    {
        get { return strAlphabet; }
        set { SetProperty(ref strAlphabet, value); }
    }
    public MainWindowViewModel(IEventAggregator eventAggregator)
    {
        KeyUpEventCommand = new DelegateCommand<KeyEventArgs>(KeyUpEventHandler);
    }
    public void KeyUpEventHandler(KeyEventArgs args)
    {
        //...
    }
