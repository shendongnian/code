    private void loadImageThumbnails(List<string> Images,string parentControlName)
        {
            int x = 0;
            int y = 0;
            foreach(string imagePath in Images)
            {
                PictureBox p = new PictureBox();
                p.ImageLocation = imagePath;
                p.Top = y;
                p.Left = x;
                p.Width = 100;
                p.Height = 100;
                p.Name = System.IO.Path.GetFileName(imagePath);
                p.Load();
                Control c = Controls.Find(parentControlName, true)[0];
                c.Controls.Add(p);
                //move left to right with 5 colums
                x += p.Width + 10;
                if (x >= 550)
                {
                    x = 0;
                    y += p.Height + 10;
                }
            }
        }
