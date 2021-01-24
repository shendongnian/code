    ImageList imgs = new ImageList();
    foreach (String item in imagearealist)
    {
        imgs.Images.Add(Bitmap.FromFile(item));
        ListViewItem newItem = new ListViewItem(item, count++));
        listView1.Items.Add(newItem);                
    }
    listView1.LargeImageList = imgs;
