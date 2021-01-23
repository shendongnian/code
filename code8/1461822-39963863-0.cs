        public Form1()
        {
            InitializeComponent();
            ListViewItem item1WithToolTip = new ListViewItem("Item with a tooltip"); // new item for listview1
            item1WithToolTip.ToolTipText = "This is the item tooltip."; // set tooltip text
            item1WithToolTip.SubItems.Add("1"); // add item
            item1WithToolTip.SubItems.Add("3");
            ListViewItem item2WithToolTip = new ListViewItem("Second item with a tooltip"); // new item for listview1
            item2WithToolTip.ToolTipText = "A different tooltip for this item.";
            item2WithToolTip.SubItems.Add("1");
            item2WithToolTip.SubItems.Add("2");
            listView1.Items.Add(item1WithToolTip);
            listView1.Items.Add(item2WithToolTip);
         }
