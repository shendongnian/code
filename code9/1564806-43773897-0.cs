    public debug()
    {
       Configure();
       InitializeComponent();
       CreateNewBrowser();
    }
    public void Configure()
    {
       CefSettings cfsettings = new CefSettings();
       cfsettings.CefCommandLineArgs.Add("proxy-server", "200.29.191.149:3128");
       cfsettings.UserAgent = "My/Custom/User-Agent-AndStuff";
       Cef.Initialize(cfsettings);
    }
    public void CreateNewBrowser()
    {
       browser = new ChromiumWebBrowser("https://whatismyipaddress.com/");     
       this.Controls.Add(browser);
       browser.Dock = DockStyle.Fill;     
    }
