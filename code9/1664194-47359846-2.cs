       private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            imageList1.Images.Clear();
            
            string[] pics = System.IO.Directory.GetFiles( "pics//");
            listView1.View = View.SmallIcon;
            listView1.SmallImageList = imageList1;
    
            imageList1.ImageSize = new Size(64, 64);
            foreach (string pic in pics)
            {
                imageList1.Images.Add(Image.FromFile(pic));
            }
    
     
            for (int j = 0; j < imageList1.Images.Count; j++)
            {
    
                ListViewItem item = new ListViewItem();
    
                item.ImageIndex = j;
    
                listView1.Items.Add(item);
                
    
            }
           
        }
