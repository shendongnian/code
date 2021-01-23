    private void DeleteButton_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem xItem in listView1.SelectedItems)
        {
            listView1.Items.Remove(xItem);
            // only delete when no longer in use:
            string key = xItem.ImageKey;
            if (listView1.Items.Cast<ListViewItem>().Count(x => x.ImageKey == key) == 0)
                imageList1.Images.RemoveByKey(key);
                
        }
        // after deletions, restore the ImageKeys
        // maybe add a check for Tag == null
        foreach (ListViewItem xItem in listView1.Items)
            xItem.ImageKey = xItem.Tag.ToString();
    }
