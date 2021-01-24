    private void Form1_Load(object sender, EventArgs e)
    {
        ImageList imageList = new ImageList {ImageSize = new Size(200, 200)};
        Image img = new Bitmap(Properties.Resources.Your_Image);
        imageList.Images.Add(img);
        this.listView1.View = View.LargeIcon;
        this.listView1.Items.Add(new ListViewItem { ImageIndex = 0 });
        this.listView1.LargeImageList = imageList;
    }
