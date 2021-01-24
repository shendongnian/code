    private void button1_Click(object sender, EventArgs e)
        {
            var imageList = new ImageList();
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                var directories = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
                foreach (string item in directories)
                {
                    FileInfo file = new FileInfo(item);                    
                    imageList.Images.Add("Key" + file.Name, Image.FromFile(file.ToString() + @"\thumbnail.png"));
                    listView1.LargeImageList = imageList;
                    var listViewItem = listView1.Items.Add(file.Name);
                    listViewItem.ImageKey = "Key" + file.Name;
                }
            }
        }
