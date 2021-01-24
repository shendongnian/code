    public ICommand Button1Command { get; }
    public ICommand Button2Command { get; }
    private ViewModel MenuView { get; }
    private ViewModel OtherView { get; }
    public ViewModel CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; OnPropertyChanged(); }
    }
    public MainWindowViewModel() 
    {
        this.MenuView = new MenuViewModel();
        this.OtherView = new OtherViewModel();
        this.Button1Command = new RelayCommand(OnButton1);
        this.Button2Command = new RelayCommand(OnButton2);
    }
    public void OnButton1()
    {
        this.CurrentView = this.MenuView;
    }
    public void OnButton2()
    {
        this.CurrentView = this.OtherView;
    }
