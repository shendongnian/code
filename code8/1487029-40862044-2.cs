    public MainWindow()
    {
        InitializeComponent();
        button.IsEnabled = false;
        browser.NavigateToString(System.IO.File.ReadAllText(@"d:\blockyHTML.html"));
    }
    private void browser_LoadCompleted(object sender, NavigationEventArgs e)
    {
        button.IsEnabled = true;
    }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        var xmlText = System.IO.File.ReadAllText(@"d:\blockyXML.xml");
        var result = browser.InvokeScript("generate", new object[] { xmlText });
        MessageBox.Show(result.ToString());
    }
