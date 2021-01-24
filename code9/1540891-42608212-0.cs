    foreach (ListViewItem listViewItem in l1.Items)
    {
        var item = l2.Items.Cast<ListViewItem>().Where(lvi => lvi.Text == listViewItem.Text);
        item.Selected=true;
    }
