    (... LOOP ...)
    //Define a new ListView Item...
    ListViewItem _LVItem = new ListViewItem(read[0].ToString());
    ListViewItem.ListViewSubItemCollection _ItemsCollection = 
                 new ListViewItem.ListViewSubItemCollection(_LVItem);
    //... and SubItems
    _ItemsCollection.Add(new ListViewItem.ListViewSubItem(_LVItem, read[1].ToString()));
    _ItemsCollection.Add(new ListViewItem.ListViewSubItem(_LVItem, read[2].ToString()));
    //No text here, this is where the image will be drawn
    _ItemsCollection.Add(new ListViewItem.ListViewSubItem(_LVItem, ""));
    //Create a new Bitmap using a MemoryStream
    _image = new Bitmap(new MemoryStream((Byte[])read[3]));
    listView1.Items.Add(_LVItem);
    (... LOOP ...)
