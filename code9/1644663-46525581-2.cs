    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        try
        {
            double width = Convert.ToDouble(e.Args[0]);
            double height = Convert.ToDouble(e.Args[1]);
            string title = e.Args[2];
            string url = e.Args[3];
            WebBrowser browser = new WebBrowser();
            Window win = new Window();
            win.Content = browser;
            win.Height = height;
            win.Width = width;
            win.Show();
            win.Title = title;
            browser.Navigate(new Uri(url, UriKind.Absolute));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
