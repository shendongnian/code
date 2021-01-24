    ...
    public DelegateCommand EnterButton { get; set; }
    public StartPageViewModel()
    {
        Title = "title_black.png";
        PasswordPlaceholder = "Lozinka";
        EnterButton = new DelegateCommand( () => { var temp = enterButtonClicked();}); 
    }
    public async Task enterButtonClicked()
    {
    }
    ...
