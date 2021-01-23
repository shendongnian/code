    public TestPage1()
    {
        InitializeComponent();
    }
    
    void ButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TestPage2());
    }
