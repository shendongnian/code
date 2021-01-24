    private ViewModelBooks _vmBooks = new ViewModelBooks();
    private ViewModelMusic _vmMusic = new ViewModelMusic();
    //  Initialized in constructor
    object[] _screens;
    public MainWindowViewModel() 
    {
        _screens = new object[] { _vmBooks, _vmMusic };
        MenuCommand = new RelayCommand(o => {
            Debug.WriteLine("Menu Command " + o);
            SwitchBooks(o);
        });            
        SelectedItem = "Bla.ViewModelBooks";           
    }
