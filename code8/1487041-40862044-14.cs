    public MainWindow()
    {
        InitializeComponent();
        showCodeButton.IsEnabled = false;
        runCodeButton.IsEnabled = false;
        browser.NavigateToString(System.IO.File.ReadAllText(@"d:\blockyHTML.html"));
    }
    private void browser_LoadCompleted(object sender, NavigationEventArgs e)
    {
        showCodeButton.IsEnabled = true;
        runCodeButton.IsEnabled = true;
        var toolboxXML = System.IO.File.ReadAllText(@"d:\blockyToolbox.xml");
        var workspaceXML = System.IO.File.ReadAllText(@"d:\blockyWorkspace.xml");
        //Initialize blocky using toolbox and workspace
        browser.InvokeScript("init", new object[] { toolboxXML, workspaceXML });
    }
    private void showCodeButton_Click(object sender, RoutedEventArgs e)
    {
        var result = browser.InvokeScript("showCode", new object[] { });
        MessageBox.Show(result.ToString());
    }
    private void runCodeButton_Click(object sender, RoutedEventArgs e)
    {
        browser.InvokeScript("runCode", new object[] { });
    }
