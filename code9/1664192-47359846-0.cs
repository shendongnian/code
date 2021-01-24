      private void button1_Click(object sender, EventArgs e)
        {
            string [] pics = System.IO.Directory.GetFiles(Application.StartupPath+ "//pics//");
        
            foreach(string pic in pics)
            {
              
                imageList1.Images.Add(Image.FromFile(pic));
            }
            this.listView1.View = View.LargeIcon;
            listView1.SmallImageList = imageList1;
            this.imageList1.ImageSize = new Size(32, 32);
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }
        }
