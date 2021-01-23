    public AutoCompleteTextBox()
    {
        InitializeComponent();
        var currentWindow = App.Current.MainWindow;
        currentWindow.Deactivated += ApplicationDeactivated;
    }
    private void ApplicationDeactivated(object sender, EventArgs e)
    {
        this.HidePropositions(); // Here is all my stuff for hiding the suggestions list
    }
