        private void Form1_Load(object sender, EventArgs e)
        {
            var folderPath = @"c:\images\";
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            var imageList = new ImageList();
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                   imageList.Images.Add(Image.FromFile(file.FullName));
                }
                catch{
                    Console.WriteLine("This is not an image file");
                }
            }
            this.listView1.View = View.LargeIcon;
            imageList.ImageSize = new Size(128, 128);
            this.listView1.LargeImageList = imageList;
            for (int j = 0; j < imageList.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }
        }
