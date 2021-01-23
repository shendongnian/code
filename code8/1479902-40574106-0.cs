    private void hideSidePanelToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (splitContainer2.Panel1Collapsed == false) 
        {
            splitContainer2.Panel1Collapsed = true;
            hideSidePanelToolStripMenuItem.Text = "Show Sidebar"
        }
        else {
            splitContainer2.Panel1Collapsed = false;
            hideSidePanelToolStripMenuItem.Text = "Hide Sidebar"
    }
