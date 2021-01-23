    addingItemID = rd.GetString(0);
    ListViewItem existing = listView3.Items.Cast<ListViewItem>().FirstOrDefault(li => li.SubItems[0].Text == addingItemID); //(not sure if the cast is needed)
    if (existing != null)
    {
        //item exists, variable existing refers to the item
        MessageBox.Show("sdsd");
    }
    else 
    {
        listView3.Items.Add(lvvi);
    }
    
