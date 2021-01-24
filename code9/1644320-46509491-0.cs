    for (var index = 0; index < SmallWords.Length; index++)
    {
        ListViewItem item = new ListViewItem(SmallWords[index]);
        if(index < LargeWords.Length)
        {
            item.SubItems.Add(LargeWords[index]);
        }
        listView1.Items.Add(item);
    }
