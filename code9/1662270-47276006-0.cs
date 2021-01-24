    private TabPage VulnTab;
    
    private void ButtonClicked(object sender, EventArgs args)
    {
        if (VulnTab != null)
        {
            tabControl1.SelectedTab = VulnTab;
        }
        else
        {
            VulnTab = new TabPage("Vulnerability");
            tabControl1.TabPages.Add(VulnTab);
    
            tabControl1.SelectedTab = VulnTab;
            var vuln = new vulnerability();
            tabControl1.SelectedTab.Controls.Add(vuln);
        }
    }
