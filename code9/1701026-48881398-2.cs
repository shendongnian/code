    async void LoginAsync()
    {
        // still main thread. Notify the operator:
        labelProgress.Text = "logging in";
        // we start something that takes some time that this cook can't spend:
        // let another cook do the logging in
        await Task.Run( () =>
        {
            wb.Navigate(Settings.Default.LoginUrl);
            WebBrowserTools.Wait(wb);
            wb.Document.GetElementById("username").InnerText = Settings.Default.LoginUsername;
            wb.Document.GetElementById("password").InnerText = Settings.Default.LoginPassword;
            wb.Document.Forms[0].InvokeMember("submit");
            WebBrowserTools.Wait(wb);
        }
        // back in main thread:
        labelProgress.Text = "logged in successfully";
    }
