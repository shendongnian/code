        public void AddItemsOne()
        {
            // Set the view to show details.
            listView1.View = View.Details;
            ListViewItem item1 = new ListViewItem("item1",0);
            // Place a check mark next to the item.
            //item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");           
            item1.SubItems.Add("4");
          
            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Item Sub Column One", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Item Sub Column Two", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Item Sub Column Three", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Item Sub Column Four", -2, HorizontalAlignment.Left);
           
            //Add the items to the ListView.
            listView1.Items.AddRange(new ListViewItem[] { item1 });
            // Add the ListView to the control collection.
            this.Controls.Add(listView1);                   
        }
