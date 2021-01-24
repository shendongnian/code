    private void btnHurriyet_Click(object sender, EventArgs e)
    {
        Hurriyet hurriyet = new Hurriyet();
        List<ListViewItem> list = hurriyet.GetTagsHurriyet();
        foreach (var item in list)
        {
            if(!IsItemPresent(item)) // You should implement this method somehow
                listView1.Items.Add(item);
        }
    }
