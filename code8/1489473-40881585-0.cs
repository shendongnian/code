	while (rd.Read())
    {
        try
        {
            imgs.Images.Add(Bitmap.FromFile("\\categories\\" + rd.GetString(2)));
			listView1.Items.Add("asas",rd.GetString(0));
        }
        catch (Exception e) {
            MessageBox.Show(e.Message);
        }
    }
    listView1.SmallImageList = imgs;
