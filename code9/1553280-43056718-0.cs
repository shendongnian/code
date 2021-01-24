    if (listView1.SelectedItems.Count == 1)
    {
        var item = listView1.SelectedItems[0];
        if (item.ImageList != null)
            pictureBox1.Image = item.ImageList.Images[item.ImageKey];
    }
