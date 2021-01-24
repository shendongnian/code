        // First you need to add an ImageList named "imageList1" to your form.
        // Then Initialize the ImageList object with images.
        for (int i = 0; i < read.Length; i++)
        {
            try
            { this.imageList1.Images.Add(Image.FromFile(read[i].ToString())); }
            catch
            { MessageBox.Show(read[i].ToString() + " is not an image file"); }
        }
        //Now You can assign the ImageList objects to your ListView.
        this.listView1.View = View.SmallIcon;
        this.listView1.SmallImageList = this.imageList1;
        for (int j = 0; j < this.imageList1.Images.Count; j++)
        {
            ListViewItem liv = new ListViewItem();
            liv.ImageIndex = j;
            this.listView1.Items.Add(liv);
        }
