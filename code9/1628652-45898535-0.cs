    listView1.Location = new System.Drawing.Point(20, 20);
    listView1.Width = 250;
    
    // The View property must be set to Details for the 
    // subitems to be visible.
    listView1.View = View.Details;
    
    // Each SubItem object requires a column, so add three columns.
    this.listView1.Columns.Add("Key", 50, HorizontalAlignment.Left);
    this.listView1.Columns.Add("Co1 1", 100, HorizontalAlignment.Left);
    this.listView1.Columns.Add("Col 2", 100, HorizontalAlignment.Left);
    
    
    // Add a ListItem (row1) object to the ListView.
    ListViewItem row1 = new ListViewItem();
    row1.Text = "Row 1";
    row1.SubItems.Add("A");
    row1.SubItems.Add("");
    listView1.Items.Add(row1);
    
    
    // Add a ListItem (row2) object to the ListView.
    ListViewItem row2 = new ListViewItem();
    row2.Text = "Row 2";
    row2.SubItems.Add("");
    row2.SubItems.Add("B");
    
    listView1.Items.Add(row2);
    
    
    // Add a SubItem to existing item (row1)
    System.Windows.Forms.ListViewItem.ListViewSubItem item1 = new ListViewItem.ListViewSubItem();
    item1.Text = "C";
    
    listView1.Items[0].SubItems[2] = item1;
