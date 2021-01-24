    listView1.Items.Clear();
    for (int i = 0; i < DTT.Rows.Count; i++)
    {
        DataRow dr = DTT.Rows[i];
        ListViewItem listitem = new ListViewItem(dr["desc"].ToString()); 
        listitem.SubItems.Add(dr["desc"].ToString());
        listitem.SubItems.Add(dr["enchimento"].ToString());
        listView1.Items.Add(listitem);
    }
