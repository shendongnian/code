    ListViewItem item1 = new ListViewItem();
    item1.SubItems.Clear();
    item1.SubItems[0].Text = "english";
    item1.SubItems.Add("22");
    item1.SubItems.Add("0.5");
    item1.BackColor = Color.Red;
    item1.ForeColor = Color.Red;
    item1.UseItemStyleForSubItems = false;
    this.listView1.Items.Add(item1);
