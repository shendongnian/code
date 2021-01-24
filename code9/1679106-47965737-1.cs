    //...
    private List<UserControl> tabContents = new List<UserControl>();
    void AddTab<T>() where T : UserControl, new()
    {
        var tab = new TabPage();
        var tabContent = new T();
        tabContents.Add(tabContent);
        tab.Controls.Add(tabContent);
        tabControl.Controls.Add(tab);
    }
    void RemoveTab(TabPage tab)
    {
        if (tab == null) throw new ArgumentNullException(nameof(tab));
    
        if (tab.Controls.Count != 0 && tab.Controls[0] is UserControl tabContent) {
            tabContents.Remove(tabContent);
        }
        tabControl.Controls.Remove(tab);
    }
    //...
