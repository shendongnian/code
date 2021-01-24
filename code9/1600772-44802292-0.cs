    private void btnHurriyet_Click(object sender, EventArgs e)
    {
        Hurriyet hurriyet = new Hurriyet();
        List<ListViewItem> list = hurriyet.GetTagsHurriyet();
        listView1.Items.Clear(); // Clear items
        foreach (var item in list)
        {
            listView1.Items.Add(item);
        }
    }
