    public bool AuthenticatedOk { get; set; }
    public identity()
    {
        InitializeComponent();
        this.AuthenticatedOk = false;
    }
    private void checkDetails(string username, string password)
    {
        if (username=="bob" && password=="password")
        {
            this.AuthenticatedOk = true;
        }
    }
