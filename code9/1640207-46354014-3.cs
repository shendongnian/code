    ...
    public AsyncCommand EnterButton { get; set; }
    public StartPageViewModel()
    {
        Title = "title_black.png";
        PasswordPlaceholder = "Lozinka";
        EnterButton = new DelegateCommand(enterButtonClicked); //you can just use a delegate, no method needed.
    }
    public async Task enterButtonClicked()
    {
    }
    ...
