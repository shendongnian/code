    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        string[] BlockArray = BlockList.ToArray();
        for (int i = 0; i < BlockArray.Length; i++)
        {
            if (e.Url.Equals(BlockList[i]))
            {
                e.Cancel = true;
                MessageBox.Show("Booyaa Says No!", "NO NO NO", MessageBoxButtons.OK, MessageBoxIcon.Hand); // Block List Error Message
            }
        }
    }
