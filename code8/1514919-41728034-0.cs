            int imgIdx = 0;
            ImageList imgList = new ImageList();
            while (reader.Read()) {
                ListViewItem item = new ListViewItem(reader.GetString(0), 0);
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                // gets image from path in db
                imgList.Images.Add(Image.FromFile(reader.GetString(3)));
                listView1.SmallImageList = imgList;
                item.SubItems.Add(reader.GetString(4));
                //  First one gets image 0, second one image 1, etc. 
                item.ImageIndex = imgIdx++;
