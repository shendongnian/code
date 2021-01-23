    public MainPage()
    {
        this.InitializeComponent();
        this.BtnLogin.Clicked += BtnLogin_Clicked;
    }
    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        this.activityIndicator.IsRunning = true;
        // TODO: do stuff here
    }
