    private void SaveTabs()
    {
        TabPanel[] tabs = new TabPanel[TabContainer1.Tabs.Count];
        TabContainer1.Tabs.CopyTo(tabs, 0);
        ViewState["tabs"] = tabs.Select(t=>t.HeaderText).ToArray();
    }
