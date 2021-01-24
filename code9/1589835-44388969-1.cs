    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        foreach (Control c in tabControl1.SelectedTab.Controls)
        {
            var web = c as WebBrowser;
            if (c != null)
            {
                web.Navigate(toolStripTextBox1.Text);
            }
        }
    }
