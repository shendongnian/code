        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            progressBar1.Value = 0;
            comboBox1.Text = webBrowser1.Url.ToString();
            if (webBrowser1.CanGoBack == false)
            {
                backButton.Enabled = false;
            }
            else
            {
                backButton.Enabled = true;
            }
            if (webBrowser1.CanGoForward == false)
            {
                forwardButton.Enabled = false;
            }
            else
            {
                forwardButton.Enabled = true;
            }
        }
