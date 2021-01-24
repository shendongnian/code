    private void timer2_Tick(object sender, EventArgs e)
    {
  
        bool exists = false;
        foreach (ListViewItem lvi in listView1.Items)
        {
            if ( lvi.SubItems(1).Text == r )
            {
                exists = true;
                lvi.SubItems(2).Text = rr;
                lvi.SubItems(3).Text = rrr;
            }
        }
        if (!exists )
        {
        ListViewItem lvi = new ListViewItem("1");
        lvi.SubItems.Add(r);
        lvi.SubItems.Add(rr);
        lvi.SubItems.Add(rrr);
        listView1.Items.Add(lvi);
        }
    }
