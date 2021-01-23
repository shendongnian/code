    OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            ofd.Multiselect = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                int x = 20;
                int y = 20;
                int maxHeight = -1;
                string[] files = ofd.FileNames;
                foreach (string img in files)
                {
                    PictureBox pic = new PictureBox();
                    pic.Click += new EventHandler(pictureBox_Click);  // call the custom event for dynamic generated PictureBox
                    pic.Image = System.Drawing.Image.FromFile(img);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Location = new System.Drawing.Point(x, y);
                    x += pic.Width + 10;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (x > this.pnlGallary.Width - 100)
                    {
                        x = 20;
                        y += maxHeight + 10;
                    }
                    this.pnlGallary.Controls.Add(pic);
                }
            }
