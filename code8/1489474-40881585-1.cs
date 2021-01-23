    listViewItem lvi = new listViewItem();
	while (rd.Read())
    {
        try
        {
            imgs.Images.Add(Bitmap.FromFile("\\categories\\" + rd.GetString(2)));
            lvi.SubItems.Add(rd.GetString(0));
        }
        catch (Exception e) {
            MessageBox.Show(e.Message);
        }
    }
    listView1.Items.Add(lvi);
    listView1.SmallImageList = imgs;
