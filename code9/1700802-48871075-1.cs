    private void LoadTabs()
    {
        string[] headers = (string[])ViewState["tabs"];
        foreach (string header in headers)
        {
            TabContainer1.Tabs.Add(new TabPanel() { HeaderText = header });
        }
    }
