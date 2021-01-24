    [SetUp]
    public void SetUp()
    {
        MockForms.Init();
    
        //This is your App.xaml and App.xaml.cs, which can have resources, etc.
        Application.Current = new App();
    }
    
    [TearDown]
    public void TearDown()
    {
        Application.Current = null;
    }
