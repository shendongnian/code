    public Main()
    {
        InitializeComponent();
        btnMarks.Enabled = !SessionManagement.CurrentUser.IsAdministrator;
    }
