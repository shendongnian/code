    private void InitializeComponent()
    {
        System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("None");
        System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("M");
        System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("E");
        System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("N");
        System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("H");
        this.scrapGroupsListView1 = new ScrapGroupsListView();
        // 
        // scrapGroupsListView1
        // 
        this.scrapGroupsListView1.CheckBoxes = true;
        this.scrapGroupsListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        listViewItem1.StateImageIndex = 0;
        listViewItem1.Tag = ScrapGroup.None;
        listViewItem2.StateImageIndex = 0;
        listViewItem2.Tag = ScrapGroup.M;
        listViewItem3.StateImageIndex = 0;
        listViewItem3.Tag = ScrapGroup.E;
        listViewItem4.StateImageIndex = 0;
        listViewItem4.Tag = ScrapGroup.N;
        listViewItem5.StateImageIndex = 0;
        listViewItem5.Tag = ScrapGroup.H;
        this.scrapGroupsListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
        listViewItem1,
        listViewItem2,
        listViewItem3,
        listViewItem4,
        listViewItem5});
