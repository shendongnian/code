    ImageList imgs = new ImageList();
    foreach (String item in imagearealist)
    {
        imgs.Images.Add(Bitmap.FromFile(item));
        listView1.Items.Add(item);                
        count++;
    }
    listView1.LargeImageList = imgs;
