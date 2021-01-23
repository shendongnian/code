    class Foo{
        ListView MainList = new ListView();
        public void createlist()
            {
    
                MainList = new ListView();
    
                DisplayPanel.Controls.Add(MainList);
    
                MainList.View = View.Details;
                MainList.GridLines = true;
    
                MainList.Name = "MainList";
                MainList.Size = DisplayPanel.Size;
                int s1 = DisplayPanel.Size.Height;
                int s2 = DisplayPanel.Size.Width;
                MainList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
    
                MainList.Columns.Add("ProductName", 100);
                MainList.Columns.Add("ProductName2", 100);
                MainList.Columns.Add("ProductName3", 100);
                MainList.Columns.Add("ProductName4", 100);
    
            }
    
    private void button1_Click(object sender, EventArgs e)
            {
    
                createlist();   //Calls function and creates the ListView
    
                ListViewItem Source = new ListViewItem("Source", 0);
                Source.Checked = true;
                Source.SubItems.Add("7");
                Source.SubItems.Add("8");
                Source.SubItems.Add("9");
    
                MainList.Items.AddRange(new ListViewItem[] {Source});
    
            }
    }
