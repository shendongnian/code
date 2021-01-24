    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        foreach (Control c in tabControl1.SelectedTab.Controls)
        {
            var web = c as WebBrowser;
            if (c != null && e.KeyCode == Keys.Enter)
            {
                web.Navigate(toolStripTextBox1.Text);
            }
        }
    }
