    private void BrowserWindow_Load(object sender, EventArgs e)
    {
        TabControl1 = new TabControl();
        TabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        Tab Tab1 = new Tab(tab_counter, getHomePageURL());
        this.Controls.Add(TabControl1);
        TabControl1.Controls.Add(Tab1.createNewTab());
    }
