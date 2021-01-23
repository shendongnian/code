    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        if (BlockList.Contains(e.Url.ToString()))
        {
            e.Cancel = true;
            MessageBox.Show("Booyaa Says No!", "NO NO NO", MessageBoxButtons.OK, MessageBoxIcon.Hand); // Block List Error Message
        }
    }
