    public ChromiumWebBrowser browser;
	private void InitBrowser()
        {
            try
            {
                if (!Cef.IsInitialized)
                {
                    CefSettings settings = new CefSettings();
                    settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");
                    Cef.Initialize(settings);
                }
                string url = "www.google.com";
                browser = new ChromiumWebBrowser(url);             
                this.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
                browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (((ChromiumWebBrowser)sender).IsBrowserInitialized)
            {
				//if needed then use dev tool
                browser.ShowDevTools();
            }
        }
