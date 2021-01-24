        private void btnZoom_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            imageList1.Images.Clear();
            string[] pics = System.IO.Directory.GetFiles(@"C:\Users\mikes\Pictures\Facebook\Backyard Wildlife"); //"TestFolder//");
            listView1.View = View.SmallIcon;
            listView1.SmallImageList = imageList1;
            imageList1.ImageSize = new Size(64, 64);
            for(int i = 0; i < pics.Length; i++)
            {
                Image img;
                using (FileStream fs = new FileStream(pics[i], FileMode.Open))
                {
                    try
                    {
                        img = Image.FromStream(fs);
                        imageList1.Images.Add(img);
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = imageList1.Images.Count - 1;
                        item.Text = System.IO.Path.GetFileNameWithoutExtension(pics[i]);
                        item.Tag = new Tuple<Image, String>(img, pics[i]);
                        listView1.Items.Add(item);
                    }
                    catch (Exception ex) { }; 
                }
                     
                
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Tuple<Image, String> data = (Tuple < Image, String >)item.Tag;
                label1.Text = data.Item2;
                pictureBox1.Image = data.Item1;
                Size sz = data.Item1.Size;
                label2.Text = sz.ToString();
            }
        }
