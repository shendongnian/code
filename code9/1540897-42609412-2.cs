    var items = from i1 in listView1.Items.Cast<ListViewItem>()
                from i2 in listView2.Items.Cast<ListViewItem>()
                where i1.SubItems.Cast<ListViewItem.ListViewSubItem>()
                        .Where((s, i) => s.Text != i2.SubItems[i].Text).Count() == 0
                select i2;
    items.ToList().ForEach(x => { x.Selected = true; });
