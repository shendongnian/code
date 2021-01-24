    private void button1_Click(object sender, EventArgs e)
    {
        int index = 0;
        foreach (Image image in images.Images)
        {
            PictureBox pf = new PictureBox();
            pf.SizeMode = PictureBoxSizeMode.StretchImage;
            pf.Height = 50;
            pf.Width = 50;
            pf.Click += new EventHandler(PictureClicked);
            pf.Name = index.ToString();
            pf.Image = image;
            flowLayoutPanel1.Controls.Add(pf);
            index++;
        }
        lblImagecount.Text = index.ToString();
    }
    private void PictureClicked(object sender, EventArgs e)
    {
        MessageBox.Show(((PictureBox) sender).Name);
    }
