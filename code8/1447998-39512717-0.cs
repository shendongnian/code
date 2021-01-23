    foreach (DataRow row in dataTable.Rows)
      {
        var image_buffer = (byte[])(row["Image"]);
        MemoryStream image_stream = new MemoryStream(image_buffer, true);
        image_stream.Write(image_buffer, 0, image_buffer.Length);
        try 
        {
            images.Images.Add(row["id"].ToString(), new Bitmap(image_stream));
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
        image_stream.Close();
        ListViewItem listItem = new ListViewItem();
        listItem.Text = row["Title"].ToString();
        listItem.ImageKey = row["Image"].ToString();
        listView1.Items.Add(listItem);
        listView1.Items.Add(row["Category"].ToString());
        listView1.Items.Add(row["Title"].ToString());
        }
