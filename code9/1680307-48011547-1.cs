        // To Convert you byte array to Images you need to convert it to a memory stream first
        // You will need to add:
        // using System.IO;
        // And you need to add an ImageList named "imageList1" to your form.
        // Then Initialize the ImageList object with images.
        for (int i = 0; i < read.Length; i++)
        {
            try
            {
                MemoryStream memStream = new MemoryStream(read[i]);
                this.imageList1.Images.Add(Image.FromStream(memStream));
            }
            catch
            { MessageBox.Show( "Image at index ( " + i.ToString() + " ) is not an image file"); }
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
